using AhliFans.Core.Feature.Entities;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.MatchCenter;

public class GetAllEventHandler :IRequestHandler<GetAllMatchImagesEvent, ActionResult>
{
  private readonly IRepository<MatchMedia> _mediaRepository;

  public GetAllEventHandler(IRepository<MatchMedia> mediaRepository)
  {
    _mediaRepository = mediaRepository;
  }
  public async Task<ActionResult> Handle(GetAllMatchImagesEvent request, CancellationToken cancellationToken)
  {
    var images = await _mediaRepository.ListAsync(new GetMediaByMatch(request.MatchId), cancellationToken);
    if (images.Count == 0) return new OkObjectResult(Enumerable.Empty<MediaImagesDto>());
    return new OkObjectResult(images.Select(m=>new MediaImagesDto(m.Id,m.MatchId,request.ImageUrl+m.Id)));
  }
}
