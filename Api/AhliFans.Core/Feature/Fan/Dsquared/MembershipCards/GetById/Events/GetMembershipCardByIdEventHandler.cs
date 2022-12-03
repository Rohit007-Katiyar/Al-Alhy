using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Dsquared.MembershipCards;

public class GetMembershipCardByIdEventHandler : IRequestHandler<GetMembershipCardByIdEvent, ActionResult>
{
  private readonly IRepository<Entities.MembershipCard> _repository;

  private readonly IValidator<GetMembershipCardByIdEvent> _validator;

  public GetMembershipCardByIdEventHandler(IRepository<MembershipCard> repository, IValidator<GetMembershipCardByIdEvent> validator)
  {
    _repository = repository;
    _validator = validator;
  }

  public async Task<ActionResult> Handle(GetMembershipCardByIdEvent request, CancellationToken cancellationToken)
  {
    var validationResult = await _validator.ValidateAsync(request, cancellationToken);
    if (!validationResult.IsValid)
    {
      var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
      var errorResponse = new FanResponse(string.Join(", ", errorMessages), ResponseStatus.Error);
      return new BadRequestObjectResult(errorResponse);
    }

    var isArabic = request.Language == Languages.Ar;

    var card = await _repository.GetByIdAsync(request.CardId, cancellationToken);
    var type = isArabic ? card!.TypeAr : card!.Type;
    var description = isArabic ? card.DescriptionAr : card.Description;
    var dto = new MembershipCardDto(card.Id, description, type, card.Months, card.Price);
    return new OkObjectResult(dto);
  }
}
