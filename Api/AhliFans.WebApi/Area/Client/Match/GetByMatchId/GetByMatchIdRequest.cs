using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Match.GetByMatchId;
public class GetByMatchIdRequest
{
    public const string Route = $"{nameof(Areas.Client)}/match/ById";
    public int MatchId { get; set; }
    public string Language { get; set; } = Languages.Ar;
}
