using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Cards;

public class GetCardsByMatchIdValidator : AbstractValidator<GetCardsByMatchIdEvent>
{
    public GetCardsByMatchIdValidator(IRepository<Entities.Match> matchesRepository)
    {
        RuleFor(ev => ev.MatchId)
        .MustAsync(async (matchId, cancellationToken) => 
        {
            var match = await matchesRepository.GetByIdAsync(matchId, cancellationToken);
            return match != null;
        })
        .WithMessage("Match is not found");
    }
}