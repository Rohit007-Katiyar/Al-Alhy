using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Dsquared.MembershipCards;
public class GetMembershipCardByIdEventHandler : IRequestHandler<GetMembershipCardByIdEvent, ActionResult>
{
  private readonly IRepository<Entities.MembershipCard> _cardsRepository;
  private readonly IValidator<GetMembershipCardByIdEvent> _validator;
  public GetMembershipCardByIdEventHandler(IRepository<MembershipCard> cardsRepository, IValidator<GetMembershipCardByIdEvent> validator)
  {
    _cardsRepository = cardsRepository;
    _validator = validator;
  }

  public async Task<ActionResult> Handle(GetMembershipCardByIdEvent request, CancellationToken cancellationToken)
  {
    var validationResult = await _validator.ValidateAsync(request, cancellationToken);
    if (!validationResult.IsValid)
    {
      var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
      var errorResponse = new AdminResponse(string.Join(", ", errorMessages), SharedKernel.Enum.ResponseStatus.Error);
      return new BadRequestObjectResult(errorResponse);
    }

    var card = await _cardsRepository.GetByIdAsync(request.CardId, cancellationToken);
    var dto = new MembershipCardDetailsDto(card.Id, card.Price, card.Type, card.TypeAr, card.Description, card.DescriptionAr, card.Months);

    return new OkObjectResult(dto);
  }
}
