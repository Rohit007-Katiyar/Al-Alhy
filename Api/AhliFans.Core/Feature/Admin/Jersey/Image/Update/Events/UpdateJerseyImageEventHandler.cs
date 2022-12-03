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

namespace AhliFans.Core.Feature.Admin.Jersey.Image.Update.Events;
public class UpdateJerseyImageEventHandler : IRequestHandler<UpdateJerseyImageEvent, ActionResult>
{
  private readonly IFileManager _fileManager;
  private readonly IRepository<Entities.Jersey> _jerseyRepository;
  
  public UpdateJerseyImageEventHandler(IFileManager fileManager, IRepository<Entities.Jersey> jerseyRepository)
  {
    _fileManager = fileManager;
    _jerseyRepository = jerseyRepository;
  }

  public async Task<ActionResult> Handle(UpdateJerseyImageEvent request, CancellationToken cancellationToken)
  {
    var jersey = await _jerseyRepository.GetByIdAsync(request.JerseyId, cancellationToken);
    if (jersey is null)
      return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    bool updateSuccess = await UpdateImageAsync(request, jersey);
    if (!updateSuccess)
      return new OkObjectResult(new AdminResponse("Failed to upload image to server", ResponseStatus.Warning));
    
    jersey.Picture = request.JeseyImage.FileName;
    jersey.ModifiedById = Guid.Parse(request.AdminId);
    jersey.ModifiedOn = DateTime.Now;
    await _jerseyRepository.UpdateAsync(jersey, cancellationToken);
    await _jerseyRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }

  private Task<bool> UpdateImageAsync(UpdateJerseyImageEvent request, Entities.Jersey jersey)
  {
    return _fileManager.UpdateFileAsync<Entities.Jersey>(request.JeseyImage, jersey.Picture!, request.JeseyImage.FileName,
      jersey.Id.ToString());
  }
}
