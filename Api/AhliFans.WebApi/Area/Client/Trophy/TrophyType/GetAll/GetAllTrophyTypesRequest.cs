#nullable disable
using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using JetBrains.Annotations;

namespace AhliFans.WebApi.Area.Client.Trophy;

public record GetAllTrophyTypesRequest
{
  public const string Route = $"{nameof(Areas.Client)}/Trophy/Types";
  [CanBeNull] public string Name { get; set; }
  public string Lang { get; set; } = Languages.Ar;
}
