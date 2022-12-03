using AhliFans.Core.Feature.Entities;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Dsquared.MembershipCards;

public class EditMembershipCardEventHandler : IRequestHandler<EditMembershipCardEvent, ActionResult>
{
  private readonly IRepository<Entities.MembershipCard> _cardsRepository;

  private readonly IValidator<EditMembershipCardEvent> _validator;

  private readonly IHttpContextAccessor _httpContextAccessor;

  private readonly IMapper _mapper;

  public EditMembershipCardEventHandler(IRepository<MembershipCard> cardsRepository, IValidator<EditMembershipCardEvent> validator, IHttpContextAccessor httpContextAccessor, IMapper mapper)
  {
    _cardsRepository = cardsRepository;
    _validator = validator;
    _httpContextAccessor = httpContextAccessor;
    _mapper = mapper;
  }

  public async Task<ActionResult> Handle(EditMembershipCardEvent request, CancellationToken cancellationToken)
  {
    var validationResult = await _validator.ValidateAsync(request, cancellationToken);
    if (!validationResult.IsValid)
    {
      var errorMessages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
      var errorResponse = new AdminResponse(string.Join(", ", errorMessages), ResponseStatus.Error);
      return new BadRequestObjectResult(errorResponse);
    }

    var claims = _httpContextAccessor.HttpContext.User.Claims;
    var adminId = Guid.Parse(claims.First(c => c.Type == "User Id").Value);

    var card = await _cardsRepository.GetByIdAsync(request.CardId, cancellationToken);
    _mapper.Map(request, card);
    card!.ModifiedBy = adminId;

    await _cardsRepository.SaveChangesAsync(cancellationToken);
    var response = new AdminResponse("Edit Successful", ResponseStatus.Success);
    return new OkObjectResult(response);
  }
}
