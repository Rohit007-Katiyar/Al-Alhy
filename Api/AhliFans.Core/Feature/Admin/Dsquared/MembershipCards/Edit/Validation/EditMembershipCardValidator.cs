using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Admin.Dsquared.MembershipCards;

public class EditMembershipCardValidator : AbstractValidator<EditMembershipCardEvent>
{
  public EditMembershipCardValidator(IRepository<Entities.MembershipCard> cardsRepository)
  {
    RuleFor(ev => ev.CardId)
      .MustAsync(async (id, cancellationToken) =>
      {
        var card = await cardsRepository.GetByIdAsync(id, cancellationToken);
        return card != null;
      })
      .WithMessage("Subscription card not found");

    RuleFor(ev => ev.Description)
      .NotEmpty()
      .NotNull()
      .WithMessage("{PropertyName} is required");

    RuleFor(ev => ev.DescriptionAr)
      .NotNull()
      .NotEmpty()
      .WithMessage("{PropertyName} is required");

    RuleFor(ev => ev.Price)
      .GreaterThanOrEqualTo(0)
      .WithMessage("{PropertyName} is invalid");

    RuleFor(ev => ev.Type)
      .NotEmpty()
      .NotNull()
      .WithMessage("{PropertyName} is required");

    RuleFor(ev => ev.TypeAr)
      .NotEmpty()
      .NotNull()
      .WithMessage("{PropertyName} is required");

    RuleFor(ev => ev.Months)
      .GreaterThanOrEqualTo(0)
      .WithMessage("{PropertyName} is invalid");
  }
}
