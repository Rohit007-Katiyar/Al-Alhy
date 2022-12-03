using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Cards;

public class GetMatchCardByIdValidator : AbstractValidator<GetMatchCardByIdEvent>
{
    public GetMatchCardByIdValidator(IRepository<Entities.MatchCard> cardsRepository)
    {
        RuleFor(ev => ev.Id)
        .MustAsync(async (cardId, cancellationToken) =>
        {
            var card = await cardsRepository.GetByIdAsync(cardId, cancellationToken);
            return card != null;
        })
        .WithMessage("Match card isn't found");
    }
}
