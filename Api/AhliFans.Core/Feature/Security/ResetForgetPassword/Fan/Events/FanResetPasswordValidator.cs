using FluentValidation;

namespace AhliFans.Core.Feature.Security.ResetForgetPassword.Fan.Events;
public class FanResetPasswordValidator : AbstractValidator<FanResetPasswordEvent>
{
  public FanResetPasswordValidator()
  {
    RuleFor(fan => fan.NewPassword).NotEmpty().WithMessage("Password is required.")
      .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,30}$").WithMessage("Your password brakes our constraints.");

    RuleFor(fan => fan.ConfirmPassword).NotEmpty().WithMessage("Password is required.")
      .Equal(fan => fan.NewPassword).WithMessage("Passwords should match.");
  }
}
