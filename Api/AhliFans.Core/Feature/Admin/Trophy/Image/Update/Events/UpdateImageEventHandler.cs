using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel.IO.FileManager;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Trophy.Image.Update.Events;

public class UpdateImageEventHandler : IRequestHandler<UpdateImageEvent,ActionResult>
{
  private readonly IFileManager _fileManager;
  private readonly IRepository<Entities.Trophy> _trophyRepository;
  public UpdateImageEventHandler(IFileManager fileManager, IRepository<Entities.Trophy> trophyRepository)
  {
    _fileManager = fileManager;
    _trophyRepository = trophyRepository;
  }
  public async Task<ActionResult> Handle(UpdateImageEvent request, CancellationToken cancellationToken)
  {
    var trophy = await _trophyRepository.GetByIdAsync(request.TrophyId,cancellationToken);
    if (trophy is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));
    
    bool image = await UpdateImageAsync(request, trophy);
    if (!image)
    {
      return new OkObjectResult(new AdminResponse("Failed to upload image to server", ResponseStatus.Warning));
    }
    trophy.Picture = request.TrophyImage.FileName;
    await _trophyRepository.UpdateAsync(trophy,cancellationToken);
    await _trophyRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }

  private Task<bool> UpdateImageAsync(UpdateImageEvent request, Entities.Trophy? trophy)
  {
    return _fileManager.UpdateFileAsync<Entities.Trophy>(request.TrophyImage, trophy?.Picture!, request.TrophyImage.FileName,
      trophy?.Id.ToString()!);
  }
}
