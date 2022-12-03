using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Team.TeamType;

public record ChangeStatusRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Team/Type/Status";
  [FromHeader] public int TeamTypeId { get; set; }
}
