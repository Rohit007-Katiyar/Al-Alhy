using AhliFans.Core.Feature.Entities;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Match;

public class GetAllEventHandler :IRequestHandler<GetAllMatchVideoEvent, ActionResult>
{
  private readonly IRepository<MatchMedia> _mediaRepository;

  public GetAllEventHandler(IRepository<MatchMedia> mediaRepository)
  {
    _mediaRepository = mediaRepository;
  }
  public async Task<ActionResult> Handle(GetAllMatchVideoEvent request, CancellationToken cancellationToken)
  {
    var videos = await _mediaRepository.ListAsync(new GetMediaByMatch(request.MatchId), cancellationToken);
    if (videos.Count == 0) return new BadRequestObjectResult(new AdminResponse("No data yet", ResponseStatus.Error));
    return new OkObjectResult(videos.Select(m=>new MediaVideoDto(m.Id,m.MatchId,m.FileName)));
  }
}
