using AhliFans.Core.Feature.Entities;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Dsquared.MembershipCards;
public class ToggleMembershipCardEventHandler : IRequestHandler<ToggleMembershipCardEvent, ActionResult>
{
  private readonly IRepository<Entities.MembershipCard> _cardsRepository;
  private readonly IValidator<ToggleMembershipCardEvent> _validator;
  private readonly IHttpContextAccessor _httpContextAccessor;
  public ToggleMembershipCardEventHandler(IRepository<MembershipCard> cardsRepository, IValidator<ToggleMembershipCardEvent> validator, IHttpContextAccessor httpContextAccessor)
  {
    _cardsRepository = cardsRepository;
    _validator = validator;
    _httpContextAccessor = httpContextAccessor;
  }

  public async Task<ActionResult> Handle(ToggleMembershipCardEvent request, CancellationToken cancellationToken)
  {
    var validationResult = await _validator.ValidateAsync(request, cancellationToken);
    if (!validationResult.IsValid)
    {
      var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
      var errorResponse = new AdminResponse(string.Join(", ", errorMessages), SharedKernel.Enum.ResponseStatus.Error);
      return new BadRequestObjectResult(errorResponse);
    }

    var claims = _httpContextAccessor.HttpContext.User.Claims;
    var adminId = Guid.Parse(claims.First(c => c.Type == "User Id").Value);

    var card = await _cardsRepository.GetByIdAsync(request.CardId, cancellationToken);
    card!.IsEnabled = !card.IsEnabled;
    card.ModifiedOn = DateTime.Now;
    card.ModifiedBy = adminId;
    await _cardsRepository.SaveChangesAsync(cancellationToken);

    var response = new AdminResponse("Edit successful", SharedKernel.Enum.ResponseStatus.Success);
    return new OkObjectResult(response);
  }
}
