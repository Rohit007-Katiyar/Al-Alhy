using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Dsquared.MembershipCards;
public class GetAllMembershipCardsEventHandler : IRequestHandler<GetAllMembershipCardsEvent, ActionResult>
{
  private readonly IRepository<Entities.MembershipCard> _cardsRepository;

  private readonly IRepository<Security.Entities.Fan> _fansRepository;

  private readonly IHttpContextAccessor _httpContextAccessor;

  public GetAllMembershipCardsEventHandler(IRepository<MembershipCard> cardsRepository, IHttpContextAccessor httpContextAccessor, IRepository<Security.Entities.Fan> fansRepository)
  {
    _cardsRepository = cardsRepository;
    _httpContextAccessor = httpContextAccessor;
    _fansRepository = fansRepository;
  }

  public async Task<ActionResult> Handle(GetAllMembershipCardsEvent request, CancellationToken cancellationToken)
  {
    var claims = _httpContextAccessor.HttpContext.User.Claims;
    var fanId = Guid.Parse(claims.First(c => c.Type == "User Id").Value);

    var fan = await _fansRepository.GetBySpecAsync(new GetFanWithMembershipCards(fanId), cancellationToken);
    var fanMembershipCardsIds = fan!.Memberships.Select(m => m.MembershipCardId).ToList();
    var isArabic = request.Language == Languages.Ar;
    var cards = await _cardsRepository.ListAsync(new GetAllMembershipCards(request.PageIndex, request.PageSize, fanMembershipCardsIds),
      cancellationToken);

    var dtos = cards.Select(c =>
      {
        var type = isArabic ? c.TypeAr : c.Type;
        var price = c.Price;
        var months = c.Months;
        var description = isArabic ? c.DescriptionAr : c.Description;
        return new MembershipCardDto(c.Id, description, type, months, price);
      })
      .ToList();

    return new OkObjectResult(dtos);
  }
}
