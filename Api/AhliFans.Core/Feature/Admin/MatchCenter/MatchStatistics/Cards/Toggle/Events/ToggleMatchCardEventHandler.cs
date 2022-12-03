using AhliFans.Core.Feature.Entities;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Cards;

public class ToggleMatchCardEventHandler : IRequestHandler<ToggleMatchCardEvent, ActionResult>
{
  private readonly IRepository<MatchCard> _cardsRepository;

  private readonly IValidator<ToggleMatchCardEvent> _validator;

  private readonly IHttpContextAccessor _httpContextAccessor;

  public ToggleMatchCardEventHandler(IRepository<MatchCard> cardsRepository, IValidator<ToggleMatchCardEvent> validator, IHttpContextAccessor httpContextAccessor)
  {
    _cardsRepository = cardsRepository;
    _validator = validator;
    _httpContextAccessor = httpContextAccessor;
  }

  public async Task<ActionResult> Handle(ToggleMatchCardEvent request, CancellationToken cancellationToken)
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

    var card = await _cardsRepository.GetByIdAsync(request.CardId, cancellationToken);
    card!.IsEnabled = !card.IsEnabled;
    card.ModifiedBy = adminIdGuid;

    await _cardsRepository.SaveChangesAsync(cancellationToken);

    var response = new AdminResponse("Edit Successful", ResponseStatus.Success);
    return new OkObjectResult(response);
  }
}