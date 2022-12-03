using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.SubAdmin;

public record AvailabilityRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Status";
  [FromHeader] public Guid AdminId { get; set; }
}
