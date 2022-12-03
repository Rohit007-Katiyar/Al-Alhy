using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Client.MatchCenter.Vote;

public record GetTopByMatchIdRequest()
{
  [FromRoute] public int MatchId { get; set; }

  [FromQuery] public int Top { get; set; }

  [FromQuery] public string? Lang { get; set; }
  public const string Route = $"{nameof(Areas.Client)}/MatchCenter/Vote/{{MatchId}}";
};