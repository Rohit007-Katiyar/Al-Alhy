using FluentValidation;

namespace AhliFans.Core.Feature.Security.Login.Admin.Events;
public class LoginEventValidator : AbstractValidator<LoginEvent>
{
  public LoginEventValidator()
  {
    RuleFor(user => user.EmailOrPhoneNumber).NotEmpty();

    RuleFor(user => user.Password).NotEmpty();

  }
}
