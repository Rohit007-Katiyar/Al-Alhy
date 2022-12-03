using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AhliFans.Core.Feature.Security.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AhliFans.Core.Feature.Security.Token.JWTHelpers;
public class JWTToken
{
  readonly UserManager<User> _userManager;
  private readonly JWT _jwt;

  public JWTToken(UserManager<User> userManager, IOptions<JWT> jwt)
  {
    _userManager = userManager;
    _jwt = jwt.Value;
  }
  public async Task<JwtSecurityToken> CreateJwtToken(User user, string active = "true", int? expires=1, bool isRoot = false)
  {
    var userClaims = await _userManager.GetClaimsAsync(user);
    var roles = await _userManager.GetRolesAsync(user);

    var roleClaims = roles.Select(role => new Claim("roles", role)).ToList();

    var claims = new[]
      {
        new Claim ("User Id", user.Id.ToString()),
        new Claim(JwtRegisteredClaimNames.Name, user.FullName),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(JwtRegisteredClaimNames.Email, user.Email == user.PhoneNumber+RootAdmin.TempEmail? "":user.Email),
        new Claim("Phone", user.PhoneNumber??"0"),
        new Claim("IsActive",active),
        new Claim("IsRoot",isRoot.ToString())
      }
      .Union(userClaims)
      .Union(roleClaims);

    var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Secret));
    var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

    var jwtSecurityToken = new JwtSecurityToken(
      issuer: _jwt.Issuer,
      audience: _jwt.Audience,
      claims: claims,
      expires: DateTime.Now.AddYears((int) expires!),
      signingCredentials: signingCredentials

    );

    return jwtSecurityToken;
  }
}
