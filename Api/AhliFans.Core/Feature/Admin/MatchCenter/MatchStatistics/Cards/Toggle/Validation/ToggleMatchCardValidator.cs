using AhliFans.Core.Feature.Enums;
using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Cards;

public class ToggleMatchCardValidator : AbstractValidator<ToggleMatchCardEvent>
{
    public ToggleMatchCardValidator(IRepository<Entities.MatchCard> cardsRepository, IRepository<Entities.Match> matchesRepository)
    {
        RuleFor(ev => ev.CardId)
        .MustAsync(async (id, cancellationToken) => 
        {
            var card = await cardsRepository.GetByIdAsync(id, cancellationToken);
            return card != null;
        })
        .DependentRules(() =>
        {
          RuleFor(ev => ev.CardId)
            .MustAsync(async (id, cancellationToken) =>
            {
              var card = await cardsRepository.GetByIdAsync(id, cancellationToken);
              var match = await matchesRepository.GetByIdAsync(card.MatchId, cancellationToken);
              return match != null && match.MatchType == MatchTypes.Live;
            })
            .WithMessage("Match is not live match or not found");
        })
        .WithMessage("Match card isn't found");
    }
}
