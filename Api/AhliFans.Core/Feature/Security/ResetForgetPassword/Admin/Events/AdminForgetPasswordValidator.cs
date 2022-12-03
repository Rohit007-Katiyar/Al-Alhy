using FluentValidation;

namespace AhliFans.Core.Feature.Security.ResetForgetPassword.Admin.Events;
public class AdminForgetPasswordValidator : AbstractValidator<AdminForgetPasswordEvent>
{
  public AdminForgetPasswordValidator()
  {
    RuleFor(admin => admin.NewPassword).NotEmpty().WithMessage("Password is required.")
      .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,30}$").WithMessage("Your password brakes our constraints.");

    RuleFor(admin => admin.ConfirmPassword).NotEmpty().WithMessage("Password is required.")
      .Equal(admin => admin.NewPassword).WithMessage("Passwords should match.");
  }
}
