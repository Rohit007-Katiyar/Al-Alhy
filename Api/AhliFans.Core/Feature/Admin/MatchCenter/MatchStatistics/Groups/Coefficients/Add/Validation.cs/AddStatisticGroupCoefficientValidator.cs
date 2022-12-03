using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups.Coefficients;

public class AddStatisticGroupCoefficientValidator : AbstractValidator<AddStatisticGroupCoefficientEvent>
{
  public AddStatisticGroupCoefficientValidator(IRepository<Entities.MatchStatisticsType> statsGroupsRepository, IRepository<Entities.MatchStatisticsTypeCoefficient> coefficientsRepository)
  {
    RuleFor(addEvent => addEvent.IsPercentage)
    .NotNull()
    .WithMessage("{PropertyName} is required");

    RuleFor(addEvent => addEvent.Name)
    .NotEmpty()
    .NotNull()
    .WithMessage("{PropertyName} is required");

    RuleFor(addEvent => addEvent.NameAr)
    .NotEmpty()
    .NotNull()
    .WithMessage("{PropertyName} is required");

    RuleFor(addEvent => addEvent.Name)
    .MustAsync(async (name, cancellationToken) =>
    {
      return await coefficientsRepository.AnyAsync(new GetCoefficientByName(name, false), cancellationToken) == false;
    })
    .WithMessage("{PropertyName} must be unique");

    RuleFor(addEvent => addEvent.NameAr)
    .MustAsync(async (name, cancellationToken) =>
    {
      return await coefficientsRepository.AnyAsync(new GetCoefficientByName(name, true), cancellationToken) == false;
    })
    .WithMessage("{PropertyName} must be unique");

    RuleFor(addEvent => addEvent.StatisticTypeId)
    .MustAsync(async (typeId, cancellationToken) =>
    {
      var statisticGroup = await statsGroupsRepository.GetByIdAsync(typeId, cancellationToken);
      return statisticGroup != null;
    })
    .WithMessage("Statistic group id is invalid");

  }
}
