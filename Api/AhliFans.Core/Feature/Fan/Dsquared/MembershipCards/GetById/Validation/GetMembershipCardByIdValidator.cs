using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Fan.Dsquared.MembershipCards.GetById.Validation;

public class GetMembershipCardByIdValidator : AbstractValidator<GetMembershipCardByIdEvent>
{
  public GetMembershipCardByIdValidator(IRepository<Entities.MembershipCard> repository)
  {
    RuleFor(ev => ev.CardId)
      .MustAsync(async (id, cancellationToken) =>
      {
        var card = await repository.GetByIdAsync(id, cancellationToken);
        return card != null;
      })
      .DependentRules(() =>
      {
        RuleFor(ev => ev.CardId)
          .MustAsync(async (id, cancellationToken) =>
          {
            var card = await repository.GetByIdAsync(id, cancellationToken);
            return card.IsEnabled;
          })
          .WithMessage("Membership card is disabled");
      })
      .WithMessage("Membership card not found");
  }
}
