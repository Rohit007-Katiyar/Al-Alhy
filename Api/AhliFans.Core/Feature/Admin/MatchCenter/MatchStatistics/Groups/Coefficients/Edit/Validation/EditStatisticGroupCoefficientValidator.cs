using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups.Coefficients;

public class EditStatisticGroupCoefficientValidator : AbstractValidator<EditStatisticGroupCoefficientEvent>
{
  public EditStatisticGroupCoefficientValidator(IRepository<Entities.MatchStatisticsType> statsGroupsRepository, IRepository<Entities.MatchStatisticsTypeCoefficient> coefficientsRepository)
  {
    RuleFor(editEvent => editEvent.Name)
    .NotNull()
    .NotEmpty()
    .WithMessage("{PropertyName} is required");

    RuleFor(editEvent => editEvent.NameAr)
    .NotNull()
    .NotEmpty()
    .WithMessage("{PropertyName} is required");

    RuleFor(editEvent => editEvent.StatisticTypeId)
    .MustAsync(async (id, cancellationToken) =>
    {
      var statisticGroup = await statsGroupsRepository.GetByIdAsync(id, cancellationToken);
      return statisticGroup != null;
    })
    .WithMessage("Statistic group id is invalid");

    RuleFor(editEvent => editEvent.IsPercentage)
    .NotNull()
    .WithMessage("{PropertyName} is required");

    RuleFor(editEvent => new { editEvent.Name, editEvent.Id })
    .MustAsync(async (obj, cancellationToken) =>
    {
      return await coefficientsRepository.AnyAsync(new CheckNameExistsForEdit(obj.Id, obj.Name, false), cancellationToken) == false;
    })
    .WithMessage("Name must be unique");

    RuleFor(editEvent => new { editEvent.NameAr, editEvent.Id })
    .MustAsync(async (obj, cancellationToken) =>
    {
      return await coefficientsRepository.AnyAsync(new CheckNameExistsForEdit(obj.Id, obj.NameAr, true), cancellationToken) == false;
    })
    .WithMessage("NameAr must be unique");

    RuleFor(editEvent => editEvent.Id)
    .MustAsync(async (id, cancellationToken) =>
    {
      var coefficient = await coefficientsRepository.GetByIdAsync(id, cancellationToken);
      return coefficient != null;
    })
    .WithMessage("{PropertyName} is invalid");
  }
}
