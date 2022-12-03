using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Moment;

public record ChangeStatusRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Moment";
  [FromHeader]public int MomentId { get; set; }
}
