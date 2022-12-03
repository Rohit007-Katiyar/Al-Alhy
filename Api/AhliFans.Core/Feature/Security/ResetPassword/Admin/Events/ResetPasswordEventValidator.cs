using FluentValidation;

namespace AhliFans.Core.Feature.Security.ResetPassword.Admin.Events;
public class ResetPasswordEventValidator : AbstractValidator<ResetPasswordEvent>
{
  public ResetPasswordEventValidator()
  {

    RuleFor(user => user.Password).NotEmpty().WithMessage("Password is required.")
      .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,30}$").WithMessage("Your password brakes our constraints.");

    RuleFor(user => user.ConfirmPassword).NotEmpty().WithMessage("Password is required.")
      .Equal(user => user.Password).WithMessage("Passwords should match.");
  }
}
