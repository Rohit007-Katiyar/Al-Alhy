using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Cards;

public class GetMatchCardByIdEventHandler : IRequestHandler<GetMatchCardByIdEvent, ActionResult>
{
  private readonly IRepository<Entities.MatchCard> _cardsRepository;

  private readonly IValidator<GetMatchCardByIdEvent> _validator;

  public GetMatchCardByIdEventHandler(IRepository<MatchCard> cardsRepository, IValidator<GetMatchCardByIdEvent> validator)
  {
    _cardsRepository = cardsRepository;
    _validator = validator;
  }

  public async Task<ActionResult> Handle(GetMatchCardByIdEvent request, CancellationToken cancellationToken)
  {
    var validationResult = await _validator.ValidateAsync(request, cancellationToken);
    if (!validationResult.IsValid)
    {
      var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
      var errorResponse = new AdminResponse(string.Join(", ", errorMessages), ResponseStatus.Error);
      return new BadRequestObjectResult(errorResponse);
    }

    var card = await _cardsRepository.GetBySpecAsync(new GetMatchCardByIdWithPlayer(request.Id), cancellationToken);
    var dto = new MatchCardDto
    {
      Id = card!.Id,
      IsEnabled = card.IsEnabled,
      IsForAhly = card.IsForAhly,
      IsRed = card.IsRed,
      Minute = card.Minute,
      PlayerId = card.PlayerId,
      PlayerName = request.Language == Languages.Ar ? card.TargetPlayer?.NameAr ?? string.Empty : card.TargetPlayer?.Name ?? string.Empty,
    };

    return new OkObjectResult(dto);
  }
}