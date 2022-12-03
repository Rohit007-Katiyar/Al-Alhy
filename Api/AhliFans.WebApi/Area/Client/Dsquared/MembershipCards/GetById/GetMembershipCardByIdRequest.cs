using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Client.Dsquared.MembershipCards;

public record GetMembershipCardByIdRequest()
{
 [FromRoute] public int CardId { get; set; }
 [FromQuery] public string? Lang { get; set; }
  public const string Route = $"{nameof(Areas.Client)}/Dsquared/MembershipCards/{{CardId}}";
};
