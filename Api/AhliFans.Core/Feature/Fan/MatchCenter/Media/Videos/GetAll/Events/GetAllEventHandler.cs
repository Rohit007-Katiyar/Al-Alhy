using AhliFans.Core.Feature.Entities;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.MatchCenter.Videos;

public class GetAllEventHandler :IRequestHandler<GetAllMatchVideosEvent, ActionResult>
{
  private readonly IRepository<MatchMedia> _mediaRepository;

  public GetAllEventHandler(IRepository<MatchMedia> mediaRepository)
  {
    _mediaRepository = mediaRepository;
  }
  public async Task<ActionResult> Handle(GetAllMatchVideosEvent request, CancellationToken cancellationToken)
  {
    var videos = await _mediaRepository.ListAsync(new GetMediaByMatch(request.MatchId), cancellationToken);
    if (videos.Count == 0) return new OkObjectResult(Enumerable.Empty<MediaVideosDto>());
    return new OkObjectResult(videos.Select(m=>new MediaVideosDto(m.Id,m.MatchId,m.FileName)));
  }
}
