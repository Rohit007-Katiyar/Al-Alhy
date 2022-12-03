using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups;

public class EditStatisticGroupValidator : AbstractValidator<EditStatisticGroupEvent>
{
  public EditStatisticGroupValidator(IRepository<Entities.MatchStatisticsType> statsGroupRepository)
  {

    RuleFor(editEvent => editEvent.Name)
    .NotNull()
    .NotEmpty()
    .WithMessage("{PropertyName} is required");

    RuleFor(editEvent => editEvent.Name)
    .NotNull()
    .NotEmpty()
    .WithMessage("{PropertyName} is required");

    RuleFor(editEvent => editEvent.IsEnabled)
    .NotNull()
    .WithMessage("{PropertyName} is required");

    RuleFor(editEvent => editEvent.Id)
    .MustAsync(async (id, cancellationToken) =>
    {
      var group = await statsGroupRepository.GetByIdAsync(id, cancellationToken);
      return group != null;
    })
    .WithMessage("Id for statistic group is invalid")
    .DependentRules(() =>
    {
      RuleFor(editEvent => new { editEvent.Name, editEvent.Id })
      .MustAsync(async (nameNId, cancellationToken) =>
      {
        return await statsGroupRepository.AnyAsync(new CheckNameIsUniqueForEdit(nameNId.Id, nameNId.Name, false), cancellationToken) == false;
      })
      .WithMessage("Name must be unique");

      RuleFor(editEvent => new { editEvent.NameAr, editEvent.Id })
      .MustAsync(async (nameNId, cancellationToken) =>
      {
        return await statsGroupRepository.AnyAsync(new CheckNameIsUniqueForEdit(nameNId.Id, nameNId.NameAr, true), cancellationToken) == false;
      })
      .WithMessage("NameAr must be unique");
    });
  }
}
