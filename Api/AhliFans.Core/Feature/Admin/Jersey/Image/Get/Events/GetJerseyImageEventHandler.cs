using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel.IO.FileManager;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Jersey.Image.Get.Events;
public class GetJerseyImageEventHandler : IRequestHandler<GetJerseyImageEvent, ActionResult>
{
  private readonly IRepository<Entities.Jersey> _jerseyRepository;
  private readonly IFileManager _fileManager;
  public GetJerseyImageEventHandler(IRepository<Entities.Jersey> jerseyRepository, IFileManager fileManager)
  {
    _jerseyRepository = jerseyRepository;
    _fileManager = fileManager;
  }
  public async Task<ActionResult> Handle(GetJerseyImageEvent request, CancellationToken cancellationToken)
  {
    var jersey = await _jerseyRepository.GetByIdAsync(request.JerseyId, cancellationToken);
    if (jersey is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    var jerseyImage = string.IsNullOrEmpty(jersey.Picture) ?
      await _fileManager.FileProxy<Entities.Jersey>("jersey.png", "") :
      await _fileManager.FileProxy<Entities.Jersey>(jersey.Picture, jersey.Id.ToString());

    try
    {
      var streamReader = await jerseyImage.ReadStreamAsync();
      return new FileStreamResult(streamReader, _fileManager.GetContentType(string.IsNullOrEmpty(jersey.Picture) ? "jersey.png" : jersey.Picture));
    }
    catch
    {
      return new BadRequestObjectResult(new AdminResponse("Can't get the image", ResponseStatus.Error));
    }
  }
}
