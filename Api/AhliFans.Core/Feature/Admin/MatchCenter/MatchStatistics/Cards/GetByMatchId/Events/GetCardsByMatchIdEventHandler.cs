using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Cards;

public class GetCardsByMatchIdEventHandler : IRequestHandler<GetCardsByMatchIdEvent, ActionResult>
{
  private readonly IRepository<Entities.MatchCard> _repository;

  private readonly IValidator<GetCardsByMatchIdEvent> _validator;

  public GetCardsByMatchIdEventHandler(IRepository<MatchCard> repository, IValidator<GetCardsByMatchIdEvent> validator)
  {
    _repository = repository;
    _validator = validator;
  }

  public async Task<ActionResult> Handle(GetCardsByMatchIdEvent request, CancellationToken cancellationToken)
  {
    var validationResult = await _validator.ValidateAsync(request, cancellationToken);
    if (!validationResult.IsValid)
    {
        var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
        var errorResponse = new AdminResponse(string.Join(", ", errorMessages), ResponseStatus.Error);
        return new BadRequestObjectResult(errorResponse);
    }

    var cards = await _repository.ListAsync(new GetCardsByMatchIdWithPlayer(request.MatchId), cancellationToken);
    var dtos = cards.Select(c => 
    {
        return new MatchCardDto
        {
            Id = c.Id,
            IsEnabled = c.IsEnabled,
            IsForAhly = c.IsForAhly,
            IsRed = c.IsRed,
            Minute = c.Minute,
            PlayerId = c.PlayerId,
            PlayerName = request.Language == Languages.Ar ? c.TargetPlayer?.NameAr ?? string.Empty : c.TargetPlayer?.Name ?? string.Empty,
        };
    }).ToList();

    return new OkObjectResult(dtos);
  }
}