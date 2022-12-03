using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Enums;
using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Goals;

public class EditMatchGoalValidator : AbstractValidator<EditMatchGoalEvent>
{
  public EditMatchGoalValidator(IRepository<MatchGoal> goalsRepository, IRepository<Entities.Match> matchesRepository, IRepository<Entities.Player> playersRepository)
  {
    RuleFor(ev => ev.Minute)
    .NotNull()
    .WithMessage("Goal minute is required");

    RuleFor(ev => ev.IsForAhly)
    .NotNull()
    .WithMessage("{PropertyName} is required");

    RuleFor(ev => ev.Id)
    .MustAsync(async (goalId, cancellationToken) =>
    {
      var goal = await goalsRepository.GetByIdAsync(goalId, cancellationToken);
      return goal != null;
    })
    .WithMessage("Match goal isn't found")
    .DependentRules(() =>
    {
      RuleFor(ev => ev.Id)
      .MustAsync(async (goalId, cancellationToken) =>
      {
        var goal = await goalsRepository.GetByIdAsync(goalId, cancellationToken);
        var match = await matchesRepository.GetByIdAsync(goal!.MatchId, cancellationToken);
        return match!.MatchType == MatchTypes.Live;
      })
      .WithMessage("Match is not live match");
    });

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
    .WithMessage("Player id is invalid");
  }
}
