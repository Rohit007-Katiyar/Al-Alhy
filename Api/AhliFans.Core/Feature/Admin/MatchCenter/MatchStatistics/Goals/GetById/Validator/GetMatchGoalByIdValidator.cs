using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Goals;

public class GetMatchGoalByIdValidator : AbstractValidator<GetMatchGoalByIdEvent>
{
  public GetMatchGoalByIdValidator(IRepository<Entities.MatchGoal> repository)
  {
    RuleFor(ev => ev.GoalId)
    .MustAsync(async (id, cancellationToken) =>
    {
      var goal = await repository.GetByIdAsync(id, cancellationToken);
      return goal != null;
    })
    .WithMessage("Match goal not found");
  }
}