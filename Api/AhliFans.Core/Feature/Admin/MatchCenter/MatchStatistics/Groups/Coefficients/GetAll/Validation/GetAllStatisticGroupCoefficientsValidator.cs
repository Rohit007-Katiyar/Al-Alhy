using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups.Coefficients;

public class GetAllStatisticGroupCoefficientsValidator : AbstractValidator<GetAllStatisticGroupCoefficientsEvent>
{
  public GetAllStatisticGroupCoefficientsValidator(IRepository<Entities.MatchStatisticsType> statsGroupsRepository)
  {
    RuleFor(getEvent => getEvent.StatisticTypeId)
    .MustAsync(async (statsGroupId, cancellationToken) =>
    {
      if (statsGroupId == null)
      {
        return true;
      }
      var statGroup = await statsGroupsRepository.GetByIdAsync((int)statsGroupId, cancellationToken);
      return statGroup != null;
    })
    .WithMessage("Statistic group id is invalid");
  }
}
