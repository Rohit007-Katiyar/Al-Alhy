using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Dsquared.MembershipCards;
public class AddMembershipCardEventHandler : IRequestHandler<AddMembershipCardEvent, ActionResult>
{
  private readonly IRepository<Entities.MembershipCard> _cardsRepository;

  private readonly IValidator<AddMembershipCardEvent> _validator;

  private readonly IHttpContextAccessor _httpContextAccessor;

  private readonly IMapper _mapper;

  public AddMembershipCardEventHandler(IHttpContextAccessor httpContextAccessor, IValidator<AddMembershipCardEvent> validator, IRepository<Entities.MembershipCard> cardsRepository, IMapper mapper)
  {
    _httpContextAccessor = httpContextAccessor;
    _validator = validator;
    _cardsRepository = cardsRepository;
    _mapper = mapper;
  }

  public async Task<ActionResult> Handle(AddMembershipCardEvent request, CancellationToken cancellationToken)
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

    var card = _mapper.Map<Entities.MembershipCard>(request);
    card.CreatedBy = adminId;
    card.ModifiedBy = adminId;

    await _cardsRepository.AddAsync(card, cancellationToken);
    await _cardsRepository.SaveChangesAsync(cancellationToken);

    var response = new AdminResponse("Membership card added successfully", SharedKernel.Enum.ResponseStatus.Success);
    return new OkObjectResult(response);
  }
}
