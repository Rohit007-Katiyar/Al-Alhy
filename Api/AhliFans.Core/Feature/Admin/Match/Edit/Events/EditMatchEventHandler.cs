using AhliFans.Core.Feature.Enums;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Match.Edit.Events;

public class EditMatchEventHandler : IRequestHandler<EditMatchEvent,ActionResult>
{
  private readonly IRepository<Entities.Match> _matchRepository;

  public EditMatchEventHandler(IRepository<Entities.Match> matchRepository)
  {
    _matchRepository = matchRepository;
  }
  public async Task<ActionResult> Handle(EditMatchEvent request, CancellationToken cancellationToken)
  {
    var match = await _matchRepository.GetByIdAsync(request.MatchId, cancellationToken);
    if (match == null) return new BadRequestObjectResult(new AdminResponse("Not found",ResponseStatus.Error));

    if (request.MatchType == MatchTypes.All)
    {
      return new BadRequestObjectResult(new AdminResponse("Can't set match type to all",
        ResponseStatus.Error));
    }

    MapMatch(request,ref match);
    await _matchRepository.UpdateAsync(match, cancellationToken);
    await _matchRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }

  private static void MapMatch(EditMatchEvent request,ref Entities.Match match)
  {
    match.SeasonId = request.SeasonId ?? match.SeasonId;
    match.OpponentTeamId = request.OpponentTeamId ?? match.OpponentTeamId;
    match.StadiumId = request.StadiumId ?? match.StadiumId;
    match.RefereeId = request.RefereeId ?? match.RefereeId;
    match.IsAway = request.IsAway ?? match.IsAway;
    match.Time = request.Time ?? match.Time;
    match.Score = request.Score ?? match.Score;
    match.OpponentScore = request.OpponentScore ?? match.OpponentScore;
    match.LeagueId = request.LeagueId ?? match.LeagueId;
    match.LeagueDateId = request.LeagueDateId ?? match.LeagueDateId;
    match.MatchType = request.MatchType ?? match.MatchType;
    match.JerseyId = request.JerseyId ?? match.JerseyId;
    match.PlannedDate = request.PlannedDate ?? match.PlannedDate;
    match.PlannedTime = request.PlannedTime ?? match.PlannedTime;
    match.ActualDate = request.ActualDate ?? match.ActualDate;
    match.ActualTime = request.ActualTime ?? match.ActualTime;
    match.MatchStatus = request.Status ?? match.MatchStatus;
    match.BroadcastChannelId = request.BroadcastChannelId ?? match.BroadcastChannelId;
  }
}
