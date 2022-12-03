using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Fan.MatchCenter.MatchStatistics.Goals;

public class GetGoalsByMatchIdValidator : AbstractValidator<GetGoalsByMatchIdEvent>
{
  public GetGoalsByMatchIdValidator(IRepository<Entities.Match> matchesRepository)
  {
    RuleFor(ev => ev.MatchId)
    .MustAsync(async (id, cancellationToken) => 
    {
        var match = await matchesRepository.GetByIdAsync(id, cancellationToken);
        return match != null;
    })
    .WithMessage("Match not found");
  }
}