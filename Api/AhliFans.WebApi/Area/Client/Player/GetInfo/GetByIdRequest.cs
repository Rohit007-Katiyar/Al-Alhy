using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Client.Player;

public class GetByIdRequest
{
  public const string Route = $"{nameof(Areas.Client)}/Player";
  [FromHeader] public int PlayerId { get; set; } 
  public string Lang { get; set; } = Languages.Ar;
}
