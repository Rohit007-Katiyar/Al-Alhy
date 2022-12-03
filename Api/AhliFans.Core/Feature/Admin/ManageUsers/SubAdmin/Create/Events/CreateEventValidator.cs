using AhliFans.Core.Feature.Security.Specifications;
using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Admin.ManageUsers.SubAdmin.Create.Events;
public class CreateEventValidator : AbstractValidator<CreateEvent>
{
  public CreateEventValidator(IRepository<Security.Entities.Admin> adminRepository)
  {
    RuleFor(admin => admin.FullName).NotEmpty().WithMessage("Bad User Name");

    RuleFor(admin => admin.PhoneNumber).NotEmpty().WithMessage("PhoneNumber is required.");
    RuleFor(admin => admin).MustAsync(async (admin, cancellationToken) =>
      await adminRepository.CountAsync(new GetByPhoneNumberWithOtp<Security.Entities.Admin>(admin.PhoneNumber), cancellationToken) == 0
    ).WithMessage("PhoneNumber is already taken");

    RuleFor(admin => admin.Password).NotEmpty().WithMessage("Password is required.")
      .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,30}$").WithMessage("Your password brakes our constraints.");

    RuleFor(admin => admin.ConfirmPassword).NotEmpty().WithMessage("Password is required.")
      .Equal(admin => admin.Password).WithMessage("Passwords should match.");
  }
}
