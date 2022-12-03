using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.SubAdmin;

public record GetByIdRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/SubAdmin";
  [FromHeader] public Guid AdminId { get; set; }
}
