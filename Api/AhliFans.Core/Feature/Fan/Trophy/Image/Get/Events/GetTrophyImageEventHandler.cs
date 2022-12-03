using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel.IO.FileManager;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Trophy.Image.Get.Events;
public class GetTrophyImageEventHandler : IRequestHandler<GetTrophyImageEvent, ActionResult>
{
  private readonly IRepository<Entities.Trophy> _trophyRepository;
  private readonly IFileManager _fileManager;
  public GetTrophyImageEventHandler(IRepository<Entities.Trophy> trophyRepository, IFileManager fileManager)
  {
    _trophyRepository = trophyRepository;
    _fileManager = fileManager;
  }
  public async Task<ActionResult> Handle(GetTrophyImageEvent request, CancellationToken cancellationToken)
  {
    var trophy = await _trophyRepository.GetByIdAsync(request.TrophyId,cancellationToken);
    if (trophy is null) return new NotFoundObjectResult(new FanResponse("Not found", ResponseStatus.Error));

    var trophyImage = string.IsNullOrEmpty(trophy.Picture) ?
      await _fileManager.FileProxy<Entities.Trophy>("defaultTrophy.png", "") :
      await _fileManager.FileProxy<Entities.Trophy>(trophy.Picture, trophy.Id.ToString());

    try
    {
       var streamRead = await trophyImage.ReadStreamAsync();
       return new FileStreamResult(streamRead, _fileManager.GetContentType(string.IsNullOrEmpty(trophy.Picture) ? "defaultTrophy.png" : trophy.Picture));
    }
    catch
    {
      return new BadRequestObjectResult(new FanResponse("Can't get the image", ResponseStatus.Error));
    }
  }
}
