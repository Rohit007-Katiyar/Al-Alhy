
using System.ComponentModel.DataAnnotations;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Account.ForgetPassword;

public record ForgetPasswordRequest([Required]string FanPhoneNumber)
{
  public const string Route = $"{nameof(Areas.Client)}/Account/ForgetPassword";
}
