using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Enums;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Match;

public class GetMatchVideoEventHandler : IRequestHandler<GetMatchVideoEvent,ActionResult>
{
  private readonly IRepository<MatchMedia> _mediaRepository;

  public GetMatchVideoEventHandler(IRepository<MatchMedia> mediaRepository)
  {
    _mediaRepository = mediaRepository;
  }
  public async Task<ActionResult> Handle(GetMatchVideoEvent request, CancellationToken cancellationToken)
  {
    var matchMedia = await _mediaRepository.GetByIdAsync(request.VideoId, cancellationToken);
    if (matchMedia is null || matchMedia.MediaType == MediaType.Photo) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    return new OkObjectResult(matchMedia.FileName ?? string.Empty);
  }
}
