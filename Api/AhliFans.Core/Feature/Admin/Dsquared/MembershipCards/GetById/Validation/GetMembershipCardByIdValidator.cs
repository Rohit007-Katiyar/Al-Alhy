using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Admin.Dsquared.MembershipCards;
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
      .WithMessage("Membership card not found");
  }
}
