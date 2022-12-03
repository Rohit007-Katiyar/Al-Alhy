using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Fans;

public record GetByIdRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Fan/{{FanId}}";
  public Guid FanId { get; set; }
}
