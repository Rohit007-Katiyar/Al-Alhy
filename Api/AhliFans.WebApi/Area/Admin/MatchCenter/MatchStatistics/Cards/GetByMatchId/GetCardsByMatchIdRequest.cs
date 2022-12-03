using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.MatchCenter.MatchStatistics.Cards;

public record GetCardsByMatchIdRequest()
{
  [FromRoute] public int MatchId { get; set; }

  [FromQuery] public string? Lang { get; set; }
  public const string Route = $"{nameof(Areas.Admin)}/MatchCenter/MatchStatistics/Cards/{{MatchId}}";
};