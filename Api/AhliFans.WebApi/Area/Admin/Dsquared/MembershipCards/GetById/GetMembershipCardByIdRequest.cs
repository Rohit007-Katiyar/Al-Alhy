using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Dsquared.MembershipCards;

public record GetMembershipCardByIdRequest
{
  [FromRoute] public int CardId { get; set; }

  public const string Route = $"{nameof(Areas.Admin)}/Dsquared/MembershipCards/{{CardId}}";
};
