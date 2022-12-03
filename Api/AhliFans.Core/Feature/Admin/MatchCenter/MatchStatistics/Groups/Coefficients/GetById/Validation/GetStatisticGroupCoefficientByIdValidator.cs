using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups.Coefficients;

public class GetStatisticGroupCoefficientByIdValidator : AbstractValidator<GetStatisticGroupCoefficientByIdEvent>
{
  public GetStatisticGroupCoefficientByIdValidator(IRepository<Entities.MatchStatisticsTypeCoefficient> repository)
  {
    RuleFor(getById => getById.StatisticGroupCoefficientId)
    .MustAsync(async (id, cancellationToken) => 
    {
      var statGroupCoefficient = await repository.GetByIdAsync(id , cancellationToken);
      return statGroupCoefficient != null;
    })
    .WithMessage("Statistic group coefficient id is invalid");
  }
}
