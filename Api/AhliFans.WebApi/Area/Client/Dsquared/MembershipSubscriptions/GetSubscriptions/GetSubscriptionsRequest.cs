using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Dsquared.MembershipSubscriptions;

public record GetSubscriptionsRequest(string? Lang)
{
  public const string Route = $"{nameof(Areas.Client)}/Dsquared/Subscriptions";
};
