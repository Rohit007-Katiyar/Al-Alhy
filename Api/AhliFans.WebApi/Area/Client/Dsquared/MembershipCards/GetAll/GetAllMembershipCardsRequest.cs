using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Dsquared.MembershipCards;

public record GetAllMembershipCardsRequest(string? Lang, int PageIndex, int PageSize)
{
  public const string Route = $"{nameof(Areas.Client)}/Dsquared/MembershipCards";
};
