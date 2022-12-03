using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Enums;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Match;

public class AddMatchMediaEventHandler : IRequestHandler<AddMatchMediaVideoEvent,ActionResult>
{
  private readonly IRepository<MatchMedia> _mediaRepository;
  private readonly IRepository<Entities.Match> _matchRepository;

  public AddMatchMediaEventHandler(IRepository<MatchMedia> mediaRepository, IRepository<Entities.Match> matchRepository)
  {
    _mediaRepository = mediaRepository;
    _matchRepository = matchRepository;
  }
  public async Task<ActionResult> Handle(AddMatchMediaVideoEvent request, CancellationToken cancellationToken)
  {
    if (!await _matchRepository.AnyAsync(new IsMatchExist(request.MatchId), cancellationToken))
      return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));
        
    foreach (var file in request.Videos)
    {
      var video = new MatchMedia() {MatchId = request.MatchId, FileName = file, IsDeleted = false,MediaType = MediaType.Video};
      await _mediaRepository.AddAsync(video, cancellationToken);
      await _mediaRepository.SaveChangesAsync(cancellationToken);
    }
    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }
}
