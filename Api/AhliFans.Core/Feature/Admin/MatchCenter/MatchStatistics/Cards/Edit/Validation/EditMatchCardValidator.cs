using AhliFans.Core.Feature.Enums;
using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Cards;

public class EditMatchCardValidator : AbstractValidator<EditMatchCardEvent>
{
  public EditMatchCardValidator(IRepository<Entities.MatchCard> cardsRepository, IRepository<Entities.Player> playersRepository, IRepository<Entities.Match> matchesRepository)
  {
    RuleFor(ev => ev.IsForAhly)
    .NotNull()
    .WithMessage("{PropertyName} is required");

    RuleFor(ev => ev.Minute)
    .GreaterThanOrEqualTo(0)
    .WithMessage("{PropertyName} is invalid");

    RuleFor(ev => ev.IsRed)
    .NotNull()
    .WithMessage("{PropertyName} is required");

    RuleFor(ev => ev)
    .MustAsync(async (ev, cancellationToken) =>
    {
      if (ev.PlayerId == null && !ev.IsForAhly)
      {
        return true;
      }
      else if (ev.PlayerId == null && ev.IsForAhly)
      {
        return false;
      }
      var player = await playersRepository.GetByIdAsync(ev.PlayerId ?? 0, cancellationToken);
      return player != null;
    })
    .WithMessage("{PropertyName} is invalid");

    RuleFor(ev => ev.Id)
    .MustAsync(async (id, cancellationToken) =>
    {
      var card = await cardsRepository.GetByIdAsync(id, cancellationToken);
      return card != null;
    })
    .DependentRules(() =>
    {
      RuleFor(ev => ev.Id)
      .MustAsync(async (id, cancellationToken) =>
      {
        var card = await cardsRepository.GetByIdAsync(id, cancellationToken);
        var match = await matchesRepository.GetByIdAsync(card!.MatchId, cancellationToken);
        return match!.MatchType == MatchTypes.Live;
      })
      .WithMessage("Match is not live match");
    })
    .WithMessage("Card id is invalid");
  }
}
