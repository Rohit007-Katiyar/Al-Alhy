using AhliFans.Core.Feature.Security.Specifications;
using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Security.ForgotPassword.Fan.Events;
public class ForgotPasswordValidator : AbstractValidator<ForgotPasswordEvent>
{
  public ForgotPasswordValidator(IRepository<Entities.Fan> adminRepository)
  {
    RuleFor(phone => phone.FanPhoneNumber).NotEmpty().WithMessage("PhoneNumber is required");
    RuleFor(phone => phone).MustAsync(async (phone, cancellationToken) =>
      await adminRepository.AnyAsync(new GetByPhoneNumberWithOtp<Entities.Fan>(phone.FanPhoneNumber), cancellationToken)
    ).WithMessage("Something was wrong with server");
  }
}
