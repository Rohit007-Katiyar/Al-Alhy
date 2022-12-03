using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Fan.MatchCenter.MatchStatistics;

public class GetByMatchIdValidator : AbstractValidator<GetByMatchIdEvent>
{
  public GetByMatchIdValidator(IRepository<Entities.Match> matchesRepository)
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