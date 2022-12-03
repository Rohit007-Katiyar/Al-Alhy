using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Stadium;

public record GetStadiumByIdRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Stadium";
  [FromHeader]public int StadiumId { get; set; }
  public string Lang { get; set; } = Languages.Ar;
}
