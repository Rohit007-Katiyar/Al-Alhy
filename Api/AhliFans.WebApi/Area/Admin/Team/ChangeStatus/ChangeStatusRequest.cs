using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Team;

public record ChangeStatusRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Team/Status";
  [FromHeader] public int TeamId { get; set; }
}
