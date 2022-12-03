using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.MatchCenter.MatchStatistics.Cards;

public record GetCardByIdRequest()
{
  [FromRoute] public int CardId { get; set; }

  [FromQuery] public string? Lang { get; set; }
  public const string Route = $"{nameof(Areas.Admin)}/MatchCenter/MatchStatistics/Card/{{CardId}}";
};