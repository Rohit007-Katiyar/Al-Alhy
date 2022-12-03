using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Profile;


public record GetByIdRequest
{
  public const string Route = $"{nameof(Areas.Client)}/Profile";
  public string Lang { get; set; } = Languages.Ar;
}
