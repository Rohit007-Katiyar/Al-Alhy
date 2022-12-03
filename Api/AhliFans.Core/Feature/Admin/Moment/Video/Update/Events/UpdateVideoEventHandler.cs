using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel.IO.FileManager;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Moment;

public class UpdateVideoEventHandler : IRequestHandler<UpdateViedoEvent,ActionResult>
{
  private readonly IFileManager _fileManager;
  private readonly IRepository<Entities.Moment> _momentRepository;
  public UpdateVideoEventHandler(IFileManager fileManager, IRepository<Entities.Moment> momentRepository)
  {
    _fileManager = fileManager;
    _momentRepository = momentRepository;
  }
  public async Task<ActionResult> Handle(UpdateViedoEvent request, CancellationToken cancellationToken)
  {
    var moment = await _momentRepository.GetByIdAsync(request.MomentId,cancellationToken);
    if (moment is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));
    
    bool image = await UpdateImageAsync(request, moment);
    if (!image)
    {
      return new OkObjectResult(new AdminResponse("Failed to upload video to server", ResponseStatus.Warning));
    }
    moment.MediaFileName = request.MomentVideo.FileName;
    await _momentRepository.UpdateAsync(moment,cancellationToken);
    await _momentRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }

  private Task<bool> UpdateImageAsync(UpdateViedoEvent request, Entities.Moment moment)
  {
    return _fileManager.UpdateFileAsync<Entities.Moment>(request.MomentVideo, moment.MediaFileName!, request.MomentVideo.FileName,
      moment.Id.ToString());
  }
}
