using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Dsquared.MembershipCards;
public class GetAllMembershipCardsEventHandler : IRequestHandler<GetAllMembershipCardsEvent, ActionResult>
{
  private readonly IRepository<Entities.MembershipCard> _cardsRepository;

  public GetAllMembershipCardsEventHandler(IRepository<MembershipCard> cardsRepository)
  {
    _cardsRepository = cardsRepository;
  }

  public async Task<ActionResult> Handle(GetAllMembershipCardsEvent request, CancellationToken cancellationToken)
  {
    var cards = await _cardsRepository.ListAsync(new GetAllMembershipCards(request.PageIndex, request.PageSize, request.IsEnabled), cancellationToken);
    var isArabic = request.Language == Languages.Ar;

    var dtos = cards.Select(c =>
    {
      var type = isArabic ? c.TypeAr : c.Type;
      var price = c.Price;
      var isEnabled = c.IsEnabled;
      var description = isArabic ? c.DescriptionAr : c.Description;
      var months = c.Months;
      var id = c.Id;
      return new MembershipCardDto(id, description, type, months, price, isEnabled);
    });

    return new OkObjectResult(dtos);
  }
}
