using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Fan.MatchCenter.Vote;

public class GetTopByMatchIdValidator : AbstractValidator<GetTopByMatchIdEvent>
{
  public GetTopByMatchIdValidator(IRepository<Entities.Match> matchesRepository)
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