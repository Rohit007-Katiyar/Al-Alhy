using AhliFans.Core.Feature.Enums;
using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics;

public class EditStatisticValidation : AbstractValidator<EditStatisticEvent>
{
  public EditStatisticValidation(IRepository<Entities.Match> matchesRepository, IRepository<Entities.MatchStatisticsType> statsGroupsRepository, IRepository<Entities.MatchStatisticsTypeCoefficient> statsGroupCoefficientsRepository, IRepository<Entities.MatchStatistic> repository)
  {
    RuleFor(editEvent => editEvent.Value)
    .NotNull()
    .GreaterThanOrEqualTo(0)
    .WithMessage("{PropertyName} is required and can't be negative");

    RuleFor(editEvent => editEvent.MatchId)
    .MustAsync(async (matchId, cancellationToken) => 
    {
      var match = await matchesRepository.GetByIdAsync(matchId, cancellationToken);
      return match != null;
    })
    .DependentRules(() => 
    {
      RuleFor(editEvent => editEvent.MatchId)
      .MustAsync(async (matchId, cancellationToken) => 
      {
        var match = await matchesRepository.GetByIdAsync(matchId, cancellationToken);
        return match!.MatchType == MatchTypes.Live;
      })
      .WithMessage("Match is not live match");
    })
    .WithMessage("Match id is invalid");

    RuleFor(editEvent => editEvent.StatisticsTypeId)
    .MustAsync(async (groupId, cancellationToken) => 
    {
      var statGroup = await statsGroupsRepository.GetByIdAsync(groupId, cancellationToken);
      return statGroup != null;
    })
    .WithMessage("Statistic group id is invalid");

    RuleFor(editEvent => editEvent.StatisticsCoefficientId)
    .MustAsync(async (coefficientId, cancellationToken) => 
    {
      var statGroupCoefficient = await statsGroupCoefficientsRepository.GetByIdAsync(coefficientId, cancellationToken);
      return statGroupCoefficient != null;
    })
    .WithMessage("Statistic coefficient id is invalid");

    RuleFor(editEvent => editEvent.Id)
    .MustAsync(async (id, cancellationToken) => 
    {
      var statistic = await repository.GetByIdAsync(id, cancellationToken);
      return statistic != null;
    })
    .WithMessage("Statistic id is invalid");

  }
}
