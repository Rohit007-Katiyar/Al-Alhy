#nullable disable
namespace AhliFans.Core.Feature.Security.Token.JWTHelpers;
public class JWT
{
  public string Secret { get; set; }
  public string Issuer { get; set; }
  public string Audience { get; set; }
}

