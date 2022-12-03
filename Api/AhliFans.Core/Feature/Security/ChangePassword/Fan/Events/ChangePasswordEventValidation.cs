using FluentValidation;

namespace AhliFans.Core.Feature.Security.ChangePassword.Fan.Events;
public class ChangePasswordEventValidation : AbstractValidator<ChangePasswordEvent>
{
  public ChangePasswordEventValidation()
  {
    RuleFor(user => user.OldPassword).NotEmpty().WithMessage("Old Password is required.");

    RuleFor(user => user.NewPassword).NotEmpty().WithMessage("New Password is required.")
      .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,30}$").WithMessage("Your New password brakes our constraints.");

    RuleFor(user => user.ConfirmPassword).NotEmpty().WithMessage("Password is required.")
      .Equal(user => user.NewPassword).WithMessage("Passwords should match.");
  }
}
