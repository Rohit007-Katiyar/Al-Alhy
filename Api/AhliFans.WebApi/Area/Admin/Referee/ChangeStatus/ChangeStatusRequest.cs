using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Referee;

public record ChangeStatusRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Referee/Status";
  [FromHeader] public int RefereeId { get; set; }

}
