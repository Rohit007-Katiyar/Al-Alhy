using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Cards;

public class EditMatchCardEventHandler : IRequestHandler<EditMatchCardEvent, ActionResult>
{
  private readonly IRepository<Entities.MatchCard> _repository;

  private readonly IValidator<EditMatchCardEvent> _validator;

  private readonly IHttpContextAccessor _httpContextAccessor;

  public EditMatchCardEventHandler(IValidator<EditMatchCardEvent> validator, IRepository<Entities.MatchCard> repository, IHttpContextAccessor httpContextAccessor)
  {
    _validator = validator;
    _repository = repository;
    _httpContextAccessor = httpContextAccessor;
  }

  public async Task<ActionResult> Handle(EditMatchCardEvent request, CancellationToken cancellationToken)
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

    var card = await _repository.GetByIdAsync(request.Id, cancellationToken);
    card!.ModifiedBy = adminIdGuid;
    card.ModifiedOn = DateTime.Now;
    card.IsForAhly = request.IsForAhly;
    card.IsRed = request.IsRed;
    card.Minute = request.Minute;
    card.PlayerId = request.PlayerId;

    await _repository.SaveChangesAsync(cancellationToken);

    var response = new AdminResponse("Match card update successful", ResponseStatus.Success);
    return new OkObjectResult(response);
  }
}