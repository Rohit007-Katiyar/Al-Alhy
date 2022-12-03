using AhliFans.Core.Feature.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Match.Add.Events;

public record AddMatchEvent(int SeasonId, int OpponentTeamId, int StadiumId, int RefereeId,int LeagueId, int LeagueDateId,
  bool IsAway, string Time, int? Score, int? OpponentScore, MatchTypes MatchType, int? JerseyId, string PlannedTime, 
  DateTime PlannedDate, string? ActualTime, DateTime? ActualDate, int? BroadcastChannelId, MatchStatus? MatchStatus) :IRequest<ActionResult>;
