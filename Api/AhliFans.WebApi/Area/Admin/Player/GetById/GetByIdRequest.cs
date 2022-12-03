using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Player;

public class GetByIdRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Player";
  [FromHeader] public int PlayerId { get; set; } 
  public string Lang { get; set; } = Languages.Ar;
}
