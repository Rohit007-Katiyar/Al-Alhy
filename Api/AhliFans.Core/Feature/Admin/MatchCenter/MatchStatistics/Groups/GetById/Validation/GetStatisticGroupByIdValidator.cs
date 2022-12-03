using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups;

public class GetStatisticGroupByIdValidator : AbstractValidator<GetStatisticGroupByIdEvent>
{
  public GetStatisticGroupByIdValidator(IRepository<Entities.MatchStatisticsType> statsGroupsRepository)
  {
    RuleFor(getEvent => getEvent.StatisticGroupId)
    .MustAsync(async (id, cancellationToken) =>
    {
      var statGroup = await statsGroupsRepository.GetByIdAsync(id, cancellationToken);
      return statGroup != null;
    })
    .WithMessage("Statistic group id is invalid");
  }
}
