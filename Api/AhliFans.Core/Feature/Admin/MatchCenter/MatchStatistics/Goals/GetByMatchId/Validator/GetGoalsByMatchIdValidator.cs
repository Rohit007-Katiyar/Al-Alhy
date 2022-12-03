using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Goals;

public class GetGoalsByMatchIdValidator : AbstractValidator<GetGoalsByMatchIdEvent>
{
    public GetGoalsByMatchIdValidator(IRepository<Entities.Match> matchesRepository)
    {
        RuleFor(ev => ev.MatchId)
        .MustAsync(async (matchId, cancellationToken) =>
        {
            var match = await matchesRepository.GetByIdAsync(matchId, cancellationToken);
            return match != null;
        })
        .WithMessage("Match isn't found");
    }
}