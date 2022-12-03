using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics;

public class GetAllMatchStatisticsValidator : AbstractValidator<GetAllMatchStatisticsEvent>
{
  public GetAllMatchStatisticsValidator(IRepository<Entities.Match> _matchesRepository)
  {
    RuleFor(ev => ev.MatchId)
    .MustAsync(async (id, cancellationToken) =>
    {
      var match = await _matchesRepository.GetByIdAsync(id, cancellationToken);
      return match != null;
    })
    .WithMessage("Match id is invalid");
  }
}