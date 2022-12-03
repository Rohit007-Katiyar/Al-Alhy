using AhliFans.Core.Feature.Enums;
using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics;

public class AddStatisticValidator : AbstractValidator<AddStatisticEvent>
{
  public AddStatisticValidator(IRepository<Entities.Match> matchesRepository, IRepository<Entities.MatchStatisticsType> statsGroupsRepository, IRepository<Entities.MatchStatisticsTypeCoefficient> statsGroupCoefficientsRepository)
  {
    RuleFor(addEvent => addEvent.Value)
    .NotNull()
    .GreaterThanOrEqualTo(0)
    .WithMessage("{PropertyName} is required and can't be negative");

    RuleFor(addEvent => addEvent.MatchId)
    .MustAsync(async (matchId, cancellationToken) => 
    {
      var match = await matchesRepository.GetByIdAsync(matchId, cancellationToken);
      return match != null;
    })
    .DependentRules(() => 
    {
      RuleFor(addEvent => addEvent.MatchId)
      .MustAsync(async (matchId, cancellationToken) => 
      {
        var match = await matchesRepository.GetByIdAsync(matchId, cancellationToken);
        return match!.MatchType == MatchTypes.Live;
      })
      .WithMessage("Match is not live match");
    })
    .WithMessage("Match id is invalid");

    RuleFor(addEvent => addEvent.StatisticsTypeId)
    .MustAsync(async (groupId, cancellationToken) => 
    {
      var statGroup = await statsGroupsRepository.GetByIdAsync(groupId, cancellationToken);
      return statGroup != null;
    })
    .WithMessage("Statistic group id is invalid");

    RuleFor(addEvent => addEvent.StatisticsCoefficientId)
    .MustAsync(async (coefficientId, cancellationToken) => 
    {
      var statGroupCoefficient = await statsGroupCoefficientsRepository.GetByIdAsync(coefficientId, cancellationToken);
      return statGroupCoefficient != null;
    })
    .WithMessage("Statistic coefficient id is invalid");

  }
}
