using AhliFans.Core.Feature.Admin.Match.GetById.DTO;
using AhliFans.Core.Feature.Admin.Match.GetById.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Match.GetById.Events;

public class GetMatchByIdEventHandler : IRequestHandler<GetMatchByIdEvent, ActionResult>
{
  private readonly IRepository<Entities.Match> _matchRepository;

  public GetMatchByIdEventHandler(IRepository<Entities.Match> matchRepository)
  {
    _matchRepository = matchRepository;
  }
  public async Task<ActionResult> Handle(GetMatchByIdEvent request, CancellationToken cancellationToken)
  {
    var match = await _matchRepository.GetBySpecAsync(new GetMatchById(request.MatchId), cancellationToken);
    if (match is null) return new NotFoundObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    var matchesDto =  new MatchDto(match.Id,match.OpponentTeam.Id.ToString(),request.Lang == Languages.En?match.OpponentTeam.Name: match.OpponentTeam.NameAr,
      match.OpponentScore,match.Score, match.Stadium.Id.ToString(),request.Lang == Languages.En?match.Stadium.Name: match.Stadium.NameAr,
                   match.IsAway,match.Time,match.Referee.Id.ToString(),request.Lang == Languages.En?match.Referee.Name:match.Referee.NameAr,match.MatchType.ToString()
                   ,match.ActualDate,match.PlannedDate,match.ActualTime , match.PlannedTime,match.JerseyId,match.SeasonId,match.LeagueId,match.LeagueDateId,match.MatchStatus,
                    request.Lang == Languages.En ? match.BroadcastChannel?.Name! : match.BroadcastChannel?.NameAr!,match.BroadcastChannelId);

    return new OkObjectResult(matchesDto);
  }
}
