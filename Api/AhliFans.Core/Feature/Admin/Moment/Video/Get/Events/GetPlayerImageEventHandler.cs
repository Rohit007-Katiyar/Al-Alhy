using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel.IO.FileManager;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Moment;
public class GetTrophyImageEventHandler : IRequestHandler<GetMomentVideoEvent,ActionResult>
{
  private readonly IRepository<Entities.Moment> _momentRepository;
  private readonly IFileManager _fileManager;
  public GetTrophyImageEventHandler(IRepository<Entities.Moment> momentRepository, IFileManager fileManager)
  {
    _momentRepository = momentRepository;
    _fileManager = fileManager;
  }
  public async Task<ActionResult> Handle(GetMomentVideoEvent request, CancellationToken cancellationToken)
  {
    var moment = await _momentRepository.GetByIdAsync(request.MomentId,cancellationToken);
    if (moment is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    var momentImage = string.IsNullOrEmpty(moment.MediaFileName) ?
      await _fileManager.FileProxy<Entities.Player>("moment.png", "") :
      await _fileManager.FileProxy<Entities.Player>(moment.MediaFileName, moment.Id.ToString());

    try
    {
      var streamReader = await momentImage.ReadStreamAsync();
      return new FileStreamResult(streamReader, _fileManager.GetContentType(string.IsNullOrEmpty(moment.MediaFileName) ? "moment.png" : moment.MediaFileName));
    }
    catch
    {
      return new BadRequestObjectResult(new AdminResponse("Can't get the video", ResponseStatus.Error));
    }
  }
}
