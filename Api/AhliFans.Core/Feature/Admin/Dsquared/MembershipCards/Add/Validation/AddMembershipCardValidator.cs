using FluentValidation;

namespace AhliFans.Core.Feature.Admin.Dsquared.MembershipCards;
public class AddMembershipCardValidator : AbstractValidator<AddMembershipCardEvent>
{
  public AddMembershipCardValidator()
  {
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
