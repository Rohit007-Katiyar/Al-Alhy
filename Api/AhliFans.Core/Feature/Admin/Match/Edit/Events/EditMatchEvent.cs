using AhliFans.Core.Feature.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Match.Edit.Events;

public record EditMatchEvent(int MatchId,int? SeasonId, int? OpponentTeamId, int? StadiumId, int? RefereeId,
  bool? IsAway, DateTime? MatchDate, string? Time, int? Score, int? OpponentScore, int? LeagueId, int? LeagueDateId,
  MatchTypes? MatchType, int? JerseyId, string? PlannedTime, DateTime? PlannedDate, string? ActualTime, DateTime? ActualDate,
  MatchStatus? Status, int? BroadcastChannelId) :IRequest<ActionResult>;
