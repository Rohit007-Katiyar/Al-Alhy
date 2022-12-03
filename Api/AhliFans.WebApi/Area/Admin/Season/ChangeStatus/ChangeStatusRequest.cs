using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Season;

public record ChangeStatusRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Season/Status";
  [FromHeader] public int SeasonId { get; set; }

}
