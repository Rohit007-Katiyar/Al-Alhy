using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Fan.Dsquared.MembershipSubscriptions.Subscribe.Validation;

public class SubscribeValidator : AbstractValidator<SubscribeEvent>
{
  public SubscribeValidator(IRepository<Entities.MembershipCard> cardsRepository)
  {
    RuleFor(ev => ev.MembershipCardId)
      .MustAsync(async (id, cancellationToken) =>
      {
        var card = await cardsRepository.GetByIdAsync(id, cancellationToken);
        return card != null;
      })
      .WithMessage("Membership card not found")
      .DependentRules(() =>
      {
        RuleFor(ev => ev.MembershipCardId)
          .MustAsync(async (id, cancellationToken) =>
          {
            var card = await cardsRepository.GetByIdAsync(id, cancellationToken);
            return card!.IsEnabled;
          }).WithMessage("Membership card is disabled");
      });

    RuleFor(ev => ev.CardNumber)
      .NotEmpty()
      .NotNull()
      .DependentRules(() =>
      {
        RuleFor(ev => ev.CardNumber)
          .Must(cardNumber =>
          {
            var number = cardNumber.Trim().Replace(" ", "");
            return number.Length == 16;
          })
          .WithMessage("Card number is invalid");
      })
      .WithMessage("{PropertyName} is required");

    RuleFor(ev => ev.Cvv)
      .NotNull()
      .NotEmpty()
      .DependentRules(() =>
      {
        RuleFor(ev => ev.Cvv)
          .Must(cvv =>
          {
            var cvvString = cvv.ToString();
            return cvvString.Length == 3;
          })
          .WithMessage("{PropertyName} is invalid");
      })
      .WithMessage("{PropertyName} is required");

    RuleFor(ev => ev.ExpiryYear)
      .NotEmpty()
      .NotNull()
      .Length(2)
      .WithMessage("{PropertyName} is invalid");

    RuleFor(ev => ev.ExpiryMonth)
      .NotEmpty()
      .NotNull()
      .Length(2)
      .WithMessage("{PropertyName} is invalid");

    RuleFor(ev => ev.Email)
      .NotEmpty()
      .NotNull()
      .EmailAddress()
      .WithMessage("{PropertyName} is invalid");

  }
}
