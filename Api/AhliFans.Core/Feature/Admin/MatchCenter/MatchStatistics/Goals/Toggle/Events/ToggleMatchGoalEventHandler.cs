using AhliFans.Core.Feature.Entities;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using Ardalis.Specification;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Goals;

public class ToggleMatchGoalEventHandler : IRequestHandler<ToggleMatchGoalEvent, ActionResult>
{
  private readonly IRepository<MatchGoal> _repository;

  private readonly IValidator<ToggleMatchGoalEvent> _validator;

  private readonly IRepository<Entities.Match> _matchesRepository;

  private readonly IHttpContextAccessor _httpContextAccessor;

  public ToggleMatchGoalEventHandler(IRepository<MatchGoal> repository, IValidator<ToggleMatchGoalEvent> validator, IRepository<Entities.Match> matchesRepository, IHttpContextAccessor httpContextAccessor)
  {
    _repository = repository;
    _validator = validator;
    _matchesRepository = matchesRepository;
    _httpContextAccessor = httpContextAccessor;
  }

  public async Task<ActionResult> Handle(ToggleMatchGoalEvent request, CancellationToken cancellationToken)
  {
    var validationResult = await _validator.ValidateAsync(request, cancellationToken);
    if (!validationResult.IsValid)
    {
      var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
      var errorResponse = new AdminResponse(string.Join(", ", errorMessages), ResponseStatus.Error);
      return new BadRequestObjectResult(errorResponse);
    }

    var claims = _httpContextAccessor.HttpContext.User.Claims;
    var adminId = claims.First(c => c.Type == "User Id").Value;
    var adminIdGuid = Guid.Parse(adminId);

    var goal = await _repository.GetByIdAsync(request.GoalId, cancellationToken);
    var match = await _matchesRepository.GetByIdAsync(goal!.MatchId, cancellationToken);

    if (goal.IsForAhly && goal.IsEnabled)
    {
      if (match!.Score != 0)
      {
        match!.Score -= 1;
      }
    }
    else if (goal.IsForAhly && !goal.IsEnabled)
    {
      match!.Score += 1;
    }
    else if (!goal.IsForAhly && !goal.IsEnabled)
    {
      match!.OpponentScore += 1;
    }
    else if (!goal.IsForAhly && goal.IsEnabled)
    {
      if (match!.OpponentScore != 0)
      {
        match!.OpponentScore -= 1;
      }
    }
    goal!.IsEnabled = !goal.IsEnabled;
    goal.ModifiedBy = adminIdGuid;

    await _repository.SaveChangesAsync(cancellationToken);

    var response = new AdminResponse("Edit Successful", ResponseStatus.Success);
    return new OkObjectResult(response);
  }
}