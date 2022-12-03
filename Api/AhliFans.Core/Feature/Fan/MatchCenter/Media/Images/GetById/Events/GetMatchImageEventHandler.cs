using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Enums;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel.IO.FileManager;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.MatchCenter;

public class GetMatchImageEventHandler : IRequestHandler<GetMatchImageEvent,ActionResult>
{
  private readonly IRepository<MatchMedia> _mediaRepository;
  private readonly IFileManager _fileManager;

  public GetMatchImageEventHandler(IRepository<MatchMedia> mediaRepository, IFileManager fileManager)
  {
    _mediaRepository = mediaRepository;
    _fileManager = fileManager;
  }
  public async Task<ActionResult> Handle(GetMatchImageEvent request, CancellationToken cancellationToken)
  {
    var matchMedia = await _mediaRepository.GetByIdAsync(request.ImageId, cancellationToken);
    if (matchMedia is null || matchMedia.MediaType == MediaType.Video) return new NotFoundObjectResult(new FanResponse("Not found", ResponseStatus.Error));

    var playerImage = string.IsNullOrEmpty(matchMedia.FileName) ?
      await _fileManager.FileProxy<MatchMedia>("defaultMedia.png", "") :
      await _fileManager.FileProxy<MatchMedia>(matchMedia.FileName, matchMedia.Id.ToString());

    try
    {
      var streamReader = await playerImage.ReadStreamAsync();
      return new FileStreamResult(streamReader, _fileManager.GetContentType(string.IsNullOrEmpty(matchMedia.FileName) ? "defaultMedia.png" : matchMedia.FileName));
    }
    catch
    {
      return new BadRequestObjectResult(new AdminResponse("Can't get the image", ResponseStatus.Error));
    }
  }
}
