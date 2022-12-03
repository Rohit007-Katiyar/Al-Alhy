using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.League;

public record ChangeStatusRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Leageue/Status";
  [FromHeader] public int LeagueId { get; set; }

}
