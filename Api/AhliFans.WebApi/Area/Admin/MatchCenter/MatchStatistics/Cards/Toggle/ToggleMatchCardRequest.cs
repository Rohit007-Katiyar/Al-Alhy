using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.MatchCenter.MatchStatistics.Cards;

public record ToggleMatchCardRequest(int CardId)
{
    public const string Route = $"{nameof(Areas.Admin)}/MatchCenter/MatchStatistics/Cards/{{CardId}}";
};