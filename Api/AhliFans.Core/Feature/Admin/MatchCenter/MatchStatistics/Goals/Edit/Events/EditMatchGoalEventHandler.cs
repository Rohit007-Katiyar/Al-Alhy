using AhliFans.Core.Feature.Entities;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Goals;

public class EditMatchGoalEventHandler : IRequestHandler<EditMatchGoalEvent, ActionResult>
{
  private readonly IRepository<MatchGoal> _goalsRepository;

  private readonly IValidator<EditMatchGoalEvent> _validator;

  private readonly IHttpContextAccessor _httpContextAccessor;

  private readonly IRepository<Entities.Match> _matchesRepository;

  public EditMatchGoalEventHandler(IRepository<MatchGoal> goalsRepository, IValidator<EditMatchGoalEvent> validator, IHttpContextAccessor httpContextAccessor, IRepository<Entities.Match> matchesRepository)
  {
    _goalsRepository = goalsRepository;
    _validator = validator;
    _httpContextAccessor = httpContextAccessor;
    _matchesRepository = matchesRepository;
  }

  public async Task<ActionResult> Handle(EditMatchGoalEvent request, CancellationToken cancellationToken)
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

    var goal = await _goalsRepository.GetByIdAsync(request.Id, cancellationToken);

    var match = await _matchesRepository.GetByIdAsync(goal!.MatchId, cancellationToken);

    var isSideChanged = request.IsForAhly != goal.IsForAhly;
    if (isSideChanged)
    {
      OnSideChanged(match!, goal);
    }

    goal!.ModifiedBy = adminIdGuid;
    goal.PlayerId = request.PlayerId;
    goal.IsForAhly = request.IsForAhly;
    goal.Minute = request.Minute;

    await _goalsRepository.SaveChangesAsync(cancellationToken);

    var response = new AdminResponse("Match goal updated successfully", ResponseStatus.Success);
    return new OkObjectResult(response);
  }

  private static void OnSideChanged(Entities.Match match, MatchGoal goal)
  {
    if (goal.IsForAhly)
    {
      if (match.Score != 0)
      {
        match.Score -= 1;
      }
      match.OpponentScore += 1;
      return;
    }
    if (match.OpponentScore != 0)
    {
      match.OpponentScore -= 1;
    }
    match.Score += 1;
  }
}