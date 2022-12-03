using AhliFans.Core.Feature.Fan.Dsquared.MembershipSubscriptions.GetSubscriptions.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Dsquared.MembershipSubscriptions;

public class GetSubscriptionsEventHandler : IRequestHandler<GetSubscriptionsEvent, ActionResult>
{
  private readonly IHttpContextAccessor _httpContextAccessor;

  private readonly IRepository<Security.Entities.Fan> _fansRepository;

  public GetSubscriptionsEventHandler(IHttpContextAccessor httpContextAccessor, IRepository<Security.Entities.Fan> fansRepository)
  {
    _httpContextAccessor = httpContextAccessor;
    _fansRepository = fansRepository;
  }

  public async Task<ActionResult> Handle(GetSubscriptionsEvent request, CancellationToken cancellationToken)
  {
    var claims = _httpContextAccessor.HttpContext.User.Claims;
    var fanId = Guid.Parse(claims.First(c => c.Type == "User Id").Value);

    var fan = await _fansRepository.GetBySpecAsync(new GetFanWithMembershipsWithCardsByFanId(fanId), cancellationToken);

    var isArabic = request.Language == Languages.Ar;
    var dtos = fan.Memberships.Select(m =>
      {
        var description = isArabic ? m.Card!.DescriptionAr : m.Card!.Description;
        var type = isArabic ? m.Card!.TypeAr : m.Card!.Type;
        var expireOn = DateOnly.FromDateTime(m.ExpireOn).ToString();
        var createdOn = DateOnly.FromDateTime(m.CreatedOn).ToString();
        return new MembershipSubscriptionDto(m.MembershipCardId, description, m.Card!.Price, expireOn, createdOn, type);
      })
      .ToList();

    return new OkObjectResult(dtos);
  }
}
