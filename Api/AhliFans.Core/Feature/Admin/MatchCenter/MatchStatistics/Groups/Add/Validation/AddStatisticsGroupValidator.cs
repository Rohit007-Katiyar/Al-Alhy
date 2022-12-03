using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups;

public class AddStatisticsGroupValidator : AbstractValidator<AddStatisticsGroupEvent>
{
  public AddStatisticsGroupValidator(IRepository<Entities.MatchStatisticsType> statsGroupsRepository)
  {
    RuleFor(addEvent => addEvent.Name)
    .NotEmpty()
    .NotNull()
    .WithMessage("{PropertyName} is required");

    RuleFor(addEvent => addEvent.Name)
    .MustAsync(async (name, cancellationToken) =>
    {
      return await statsGroupsRepository.AnyAsync(new GetGroupByName(name, false), cancellationToken) == false;
    })
    .WithMessage("{PropertyName} must be unique");

    RuleFor(addEvent => addEvent.NameAr)
    .NotEmpty()
    .NotNull()
    .WithMessage("{PropertyName} is required");

    RuleFor(addEvent => addEvent.NameAr)
    .MustAsync(async (name, cancellationToken) =>
    {
      return await statsGroupsRepository.AnyAsync(new GetGroupByName(name, true), cancellationToken) == false;
    })
    .WithMessage("{PropertyName} must be unique");
  }
}
