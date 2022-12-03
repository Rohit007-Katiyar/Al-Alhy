using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Dsquared.MembershipCards;

public record GetAllMembershipCardsRequest(string? Lang, int PageIndex, int PageSize, bool IsEnabled)
{
  public const string Route = $"{nameof(Areas.Admin)}/Dsquared/MembershipCards";
}
