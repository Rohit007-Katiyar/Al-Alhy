using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Admin.Dsquared.MembershipCards.Toggle;
public class ToggleMembershipCardValidator : AbstractValidator<ToggleMembershipCardEvent>
{
  public ToggleMembershipCardValidator(IRepository<Entities.MembershipCard> repository)
  {
    RuleFor(ev => ev.CardId)
      .MustAsync(async (id, cancellationToken) =>
      {
        var card = await repository.GetByIdAsync(id, cancellationToken);
        return card != null;
      })
      .WithMessage("Membership card not found");
  }
}
