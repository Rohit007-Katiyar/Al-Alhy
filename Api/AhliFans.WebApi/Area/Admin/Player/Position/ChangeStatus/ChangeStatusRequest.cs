using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Player.Position;

public record ChangeStatusRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Player/Position/Status";
  [FromHeader] public int PositionId { get; set; }

}
