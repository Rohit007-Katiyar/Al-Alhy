
using System.ComponentModel.DataAnnotations;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Account;

public record ForgetPasswordRequest([Required]string PhoneNumber)
{
  public const string Route = $"{nameof(Areas.Admin)}/ForgetPassword";
}
