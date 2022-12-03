using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Fans;

public class ChangeStatusRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Fan/Status";
  [FromHeader] public Guid FanId { get; set; }
}
