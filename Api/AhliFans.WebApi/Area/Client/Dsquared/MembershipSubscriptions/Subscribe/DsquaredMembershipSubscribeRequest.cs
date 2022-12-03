using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Client.Dsquared.MembershipSubscriptions;

public record DsquaredMembershipSubscribeRequest()
{
  public record Body
  {
    public int MembershipCardId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string CardNumber { get; set; } = string.Empty;
    public int Cvv { get; set; }
    public string ExpiryYear { get; set; } = string.Empty;
    public string ExpiryMonth { get; set; } = string.Empty;
  }

  [FromBody] public Body RequestBody { get; set; }

  [FromQuery] public string? Lang { get; set; }
  public const string Route = $"{nameof(Areas.Client)}/Dsquared/Subscribe";
};
