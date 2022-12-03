using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;


namespace AhliFans.WebApi.Area.Admin.Season;

public record GetByIdRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Season";
  [FromHeader]public int SeasonId { get; set; }
  public string Lang { get; set; } = Languages.Ar;
}
