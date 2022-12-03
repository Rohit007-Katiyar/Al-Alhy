using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Coach.Title;

public record GetByIdRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Coach/Title";
  [FromHeader]public int TitleId { get; set; }
}
