using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Fan.Dsquared.MembershipSubscriptions.Subscribe.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.APIServices.Fawry.IRepository;
using AhliFans.SharedKernel.APIServices.Fawry.Model;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Dsquared.MembershipSubscriptions.Subscribe;

public class SubscribeEventHandler : IRequestHandler<SubscribeEvent, ActionResult>
{
  private readonly IValidator<SubscribeEvent> _validator;

  private readonly IRepository<Security.Entities.Fan> _fansRepository;

  private readonly IRepository<Entities.MembershipCard> _cardsRepository;

  private readonly IFawryPaymentService _paymentService;

  private readonly IHttpContextAccessor _httpContextAccessor;

  public SubscribeEventHandler(IValidator<SubscribeEvent> validator, IRepository<Security.Entities.Fan> fansRepository, IFawryPaymentService paymentService, IHttpContextAccessor httpContextAccessor, IRepository<MembershipCard> cardsRepository)
  {
    _validator = validator;
    _fansRepository = fansRepository;
    _paymentService = paymentService;
    _httpContextAccessor = httpContextAccessor;
    _cardsRepository = cardsRepository;
  }

  public async Task<ActionResult> Handle(SubscribeEvent request, CancellationToken cancellationToken)
  {
    var validationResult = await _validator.ValidateAsync(request, cancellationToken);
    if (!validationResult.IsValid)
    {
      var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
      var errorResponse = new FanResponse(string.Join(", ", errorMessages), ResponseStatus.Error);
      return new BadRequestObjectResult(errorResponse);
    }

    var claims = _httpContextAccessor.HttpContext.User.Claims;
    var fanId = Guid.Parse(claims.First(c => c.Type == "User Id").Value);

    var fan = await _fansRepository.GetBySpecAsync(new GetFanWithMembershipsById(fanId), cancellationToken);
    var alreadySubscribed = IsAlreadySubscribed(request.MembershipCardId, fan!.Memberships.ToList());
    if (alreadySubscribed)
    {
      var error = new FanResponse("You're already subscribed", ResponseStatus.Error);
      return new BadRequestObjectResult(error);
    }

    var card = await _cardsRepository.GetByIdAsync(request.MembershipCardId, cancellationToken);

    fan.Email = request.Email;
    var paymentModel = GetPaymentModel(request, fan, card!, request.Language == Languages.Ar);

    var paymentResult = await _paymentService.PayAsync(paymentModel);
    if (!paymentResult.IsSuccessful)
    {
      //when fawry works return bad request
      Console.WriteLine(paymentResult.ErrorMessage);
    }

    var membership = new UserMembership
    {
      MembershipCardId = request.MembershipCardId,
      CreatedOn = DateTime.Now,
      ExpireOn = DateTime.Now.AddMonths(card!.Months),
      UserId = fanId
    };

    fan.Memberships.Add(membership);

    await _fansRepository.SaveChangesAsync(cancellationToken);

    var response = new FanResponse("Membership subscription is successful", ResponseStatus.Success);
    return new OkObjectResult(response);
  }

  private bool IsAlreadySubscribed(int cardId, List<UserMembership> memberships)
  {
    return memberships.Exists(m => m.MembershipCardId == cardId && !m.IsExpired);
  }

  private static PaymentModel GetPaymentModel(SubscribeEvent request, Security.Entities.Fan fan, MembershipCard card, bool isArabic)
  {
    var item = new Item
    {
      Description = isArabic ? card.DescriptionAr : card.Description, Id = card.Id, Price = card.Price, Quantity = 1
    };
    return new PaymentModel
    {
      Amount = card.Price,
      Description = isArabic ? card.DescriptionAr : card.Description,
      CardNumber = request.CardNumber,
      CardExpiryYear = request.ExpiryYear,
      CardExpiryMonth = request.ExpiryMonth,
      CustomerProfileId = fan.Id.ToString(),
      CustomerEmail = fan.Email,
      CustomerMobile = fan.PhoneNumber,
      CustomerName = fan.FullName,
      Language = isArabic? Languages.Ar : Languages.En,
      Cvv = request.Cvv,
      MerchantRefNum = card.Id.ToString(),
      Items = new List<Item>{item}
    };
  }
}
