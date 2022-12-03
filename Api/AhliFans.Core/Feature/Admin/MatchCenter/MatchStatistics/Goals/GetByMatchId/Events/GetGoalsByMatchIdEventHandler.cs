using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Goals;

public class GetGoalsByMatchIdEventHandler : IRequestHandler<GetGoalsByMatchIdEvent, ActionResult>
{
  private readonly IValidator<GetGoalsByMatchIdEvent> _validator;

  private readonly IRepository<MatchGoal> _repository;

  public GetGoalsByMatchIdEventHandler(IValidator<GetGoalsByMatchIdEvent> validator, IRepository<MatchGoal> repository)
  {
    _validator = validator;
    _repository = repository;
  }

  public async Task<ActionResult> Handle(GetGoalsByMatchIdEvent request, CancellationToken cancellationToken)
  {
    var validationResult = await _validator.ValidateAsync(request, cancellationToken);
    if (!validationResult.IsValid)
    {
        var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
        var errorResponse = new AdminResponse(string.Join(", ", errorMessages), ResponseStatus.Error);
        return new BadRequestObjectResult(errorResponse);
    }

    var goals = await _repository.ListAsync(new GetGoalsByMatchId(request.MatchId), cancellationToken);
    var dtos = goals.Select(g => new MatchGoalDto
    {
        Id = g.Id,
        IsForAhly = g.IsForAhly,
        PlayerId = g.PlayerId,
        PlayerName = request.Language == Languages.Ar ? g.Scorer?.NameAr ?? string.Empty: g.Scorer?.Name ?? string.Empty,
        Minute = g.Minute,
        IsEnabled = g.IsEnabled
    }).ToList();

    return new OkObjectResult(dtos);
  }
}