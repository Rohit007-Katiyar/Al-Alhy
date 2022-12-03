using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Interfaces;
using Ardalis.Specification;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Goals;

public class GetMatchGoalByIdEventHandler : IRequestHandler<GetMatchGoalByIdEvent, ActionResult>
{
  private readonly IRepository<Entities.MatchGoal> _repository;

  private readonly IValidator<GetMatchGoalByIdEvent> _validator;

  public GetMatchGoalByIdEventHandler(IRepository<MatchGoal> repository, IValidator<GetMatchGoalByIdEvent> validator)
  {
    _repository = repository;
    _validator = validator;
  }

  public async Task<ActionResult> Handle(GetMatchGoalByIdEvent request, CancellationToken cancellationToken)
  {
    var validationResult = await _validator.ValidateAsync(request, cancellationToken);
    if (!validationResult.IsValid)
    {
      var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
      var errorResponse = new AdminResponse(string.Join(", ", errorMessages), SharedKernel.Enum.ResponseStatus.Error);
      return new BadRequestObjectResult(errorResponse);
    }

    var goal = await _repository.GetBySpecAsync(new GetMatchGoalByIdWithPlayer(request.GoalId), cancellationToken);
    var dto = new MatchGoalDto
    {
        Id = goal!.Id,
        IsEnabled = goal.IsEnabled,
        IsForAhly = goal.IsForAhly,
        Minute = goal.Minute,
        PlayerId = goal.PlayerId,
        PlayerName = request.Language == Languages.Ar ? goal.Scorer?.NameAr ?? string.Empty : goal.Scorer?.Name ?? string.Empty
    };

    return new OkObjectResult(dto);
  }
}