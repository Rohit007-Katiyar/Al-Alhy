using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Match.GetById;

public class GetByIdRequest
{
  public const string Route = $"{nameof(Areas.Client)}/match";
  public int MatchId { get; set; }
  public string Language { get; set; } = Languages.Ar;
}
