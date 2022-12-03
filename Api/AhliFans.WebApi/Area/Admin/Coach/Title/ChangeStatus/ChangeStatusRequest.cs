using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Coach.Title;

public record ChangeStatusRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Coach/Title/Status";
  [FromHeader] public int TitleId { get; set; }

}
