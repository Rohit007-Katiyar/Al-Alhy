using AhliFans.Core.Feature.Enums;
using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Goals;

public class ToggleMatchEventValidator : AbstractValidator<ToggleMatchGoalEvent>
{
    public ToggleMatchEventValidator(IRepository<Entities.MatchGoal> repository, IRepository<Entities.Match> matchesRepository)
    {
        RuleFor(ev => ev.GoalId)
        .MustAsync(async (id, cancellationToken) => 
        {
            var goal = await repository.GetByIdAsync(id, cancellationToken);
            return goal != null;
        })
        .DependentRules(() =>
        {
          RuleFor(ev => ev.GoalId)
            .MustAsync(async (id, cancellationToken) =>
            {
              var goal = await repository.GetByIdAsync(id, cancellationToken);
              var match = await matchesRepository.GetByIdAsync(goal.MatchId, cancellationToken);
              return match != null && match.MatchType == MatchTypes.Live;
            })
            .WithMessage("Match is not live match or not found");
        })
        .WithMessage("Match goal isn't found");
    }
}
