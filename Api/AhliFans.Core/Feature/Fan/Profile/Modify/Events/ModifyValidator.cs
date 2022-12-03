using AhliFans.Core.Feature.Security.Specifications;
using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Fan.Profile.Modify.Events;
public class ModifyValidator : AbstractValidator<ModifyEvent>
{
  public ModifyValidator(IRepository<Security.Entities.Fan> fanRepository)
  {
    RuleFor(fan => fan).MustAsync(async (fan, cancellationToken) =>
      await fanRepository.AnyAsync(new GetByEmail<Security.Entities.Fan>(fan.Email!), cancellationToken)
    ).WithMessage("Something was wrong with server");
  }
}
