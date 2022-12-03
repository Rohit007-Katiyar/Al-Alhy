using AhliFans.Core.Feature.Security.Specifications;
using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Security.ForgotPassword.Admin.Events;
public class ForgotPasswordValidator : AbstractValidator<ForgotPasswordEvent>
{
  public ForgotPasswordValidator(IRepository<Entities.Admin> adminRepository)
  {
    RuleFor(phone => phone.PhoneNumber).NotEmpty().WithMessage("phone is required");
    RuleFor(phone => phone).MustAsync(async (phone, cancellationToken) =>
      await adminRepository.AnyAsync(new GetByPhoneNumberWithOtp<Entities.Admin>(phone.PhoneNumber), cancellationToken)
    ).WithMessage("Something was wrong with server");
  }
}
