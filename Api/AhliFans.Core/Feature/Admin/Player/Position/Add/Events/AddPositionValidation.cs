using FluentValidation;

namespace AhliFans.Core.Feature.Admin.Player.Position.Add.Events;

public class AddPositionValidation : AbstractValidator<AddPositionEvent>
{
  public AddPositionValidation()
  {
    RuleFor(p => p.Name).NotNull().NotEmpty().WithMessage("Name is required");
    RuleFor(p => p.NameAr).NotNull().NotEmpty().WithMessage("Arabic Name is required");
    RuleFor(p => p.Symbol).MaximumLength(2).WithMessage("The symbol max length is 2 like 'CB,GK...'");
  }
}
