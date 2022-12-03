using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Player;

public record ChangeStatusRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Player/Status";
  [FromHeader]public int PlayerId { get; set; }
}
