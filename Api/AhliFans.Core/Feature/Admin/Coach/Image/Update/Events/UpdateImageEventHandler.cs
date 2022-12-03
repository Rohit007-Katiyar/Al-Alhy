using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel.IO.FileManager;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.Image.Update.Events;

public class UpdateImageEventHandler : IRequestHandler<UpdateImageEvent,ActionResult>
{
  private readonly IFileManager _fileManager;
  private readonly IRepository<Entities.Coach> _coachRepository;
  public UpdateImageEventHandler(IFileManager fileManager, IRepository<Entities.Coach> coachRepository)
  {
    _fileManager = fileManager;
    _coachRepository = coachRepository;
  }
  public async Task<ActionResult> Handle(UpdateImageEvent request, CancellationToken cancellationToken)
  {
    var coach = await _coachRepository.GetByIdAsync(request.CoachId, cancellationToken);
    if (coach is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));
    
    bool image = await UpdateImageAsync(request, coach);
    if (!image)
    {
      return new OkObjectResult(new AdminResponse("Failed to upload image to server", ResponseStatus.Warning));
    }
    coach.Pic = request.CoachImage.FileName;
    await _coachRepository.UpdateAsync(coach, cancellationToken);
    await _coachRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }

  private Task<bool> UpdateImageAsync(UpdateImageEvent request, Entities.Coach coach)
  {
    return _fileManager.UpdateFileAsync<Entities.Coach>(request.CoachImage, coach.Pic!, request.CoachImage.FileName,
      coach.Id.ToString());
  }
}
