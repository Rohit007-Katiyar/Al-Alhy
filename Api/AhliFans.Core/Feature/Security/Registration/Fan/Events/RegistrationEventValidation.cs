using AhliFans.Core.Feature.Security.Specifications;
using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Security.Registration.Fan.Events;
public class RegistrationEventValidation : AbstractValidator<RegistrationEvent>
{
  public RegistrationEventValidation(IRepository<Entities.Fan> fanRepository)
  {
    RuleFor(user => user.FullName).NotEmpty().WithMessage("Full Name is required");

    RuleFor(fan => fan.PhoneNumber).NotEmpty().WithMessage("PhoneNumber is required.");
    RuleFor(fan => fan).MustAsync(async (fan, cancellationToken) =>
      await fanRepository.CountAsync(new GetByPhoneNumberWithOtp<Entities.Fan>(fan.PhoneNumber), cancellationToken) == 0
    ).WithMessage("PhoneNumber is already taken");

    RuleFor(fan => fan.Password).NotEmpty().WithMessage("Password is required.")
      .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&#])[A-Za-z\d@$!%*?&]{8,30}$").WithMessage("Your password brakes our constraints.");

    RuleFor(fan => fan.ConfirmPassword).NotEmpty().WithMessage("Password is required.")
      .Equal(fan => fan.Password).WithMessage("Passwords should match.");

  }
}
