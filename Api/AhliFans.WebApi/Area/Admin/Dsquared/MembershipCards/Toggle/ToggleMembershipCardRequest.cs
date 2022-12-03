using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Dsquared.MembershipCards;

public record ToggleMembershipCardRequest(int CardId)
{
  public const string Route = $"{nameof(Areas.Admin)}/Dsquared/MembershipCards/{{CardId}}";
};
