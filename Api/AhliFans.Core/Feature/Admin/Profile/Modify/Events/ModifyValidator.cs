using AhliFans.Core.Feature.Security.Specifications;
using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Admin.Profile.Modify.Events;
public class ModifyValidator : AbstractValidator<ModifyEvent>
{
  public ModifyValidator(IRepository<Security.Entities.Admin> fanRepository)
  {
    RuleFor(admin => admin).MustAsync(async (admin, cancellationToken) =>
      await fanRepository.AnyAsync(new GetByEmail<Security.Entities.Admin>(admin.Email!), cancellationToken)
    ).WithMessage("Something was wrong with server");
  }
}
