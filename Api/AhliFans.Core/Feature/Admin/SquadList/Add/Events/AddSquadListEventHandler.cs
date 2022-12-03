using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.SquadList.Add.Events;

public class AddSquadListEventHandler : IRequestHandler<AddSquadListEvent, ActionResult>
{
  private readonly IRepository<Entities.SquadList> _squadRepository;

  private readonly IValidator<AddSquadListEvent> _validator;

  private readonly UserManager<Security.Entities.Admin> _userManager;

  private readonly IHttpContextAccessor _httpContextAccessor;

  public AddSquadListEventHandler(IRepository<Entities.SquadList> squadRepository, IValidator<AddSquadListEvent> validator, UserManager<Security.Entities.Admin> userManager, IHttpContextAccessor httpContextAccessor)
  {
    _squadRepository = squadRepository;
    _validator = validator;
    _userManager = userManager;
    _httpContextAccessor = httpContextAccessor;
  }
  public async Task<ActionResult> Handle(AddSquadListEvent request, CancellationToken cancellationToken)
  {
    var validationResult = await _validator.ValidateAsync(request, cancellationToken);
    if (!validationResult.IsValid)
    {
      var errorResponse = new AdminResponse(string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)), ResponseStatus.Error);
      return new BadRequestObjectResult(errorResponse);
    }

    var adminId = _httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == "User Id").Value;

    var admin = await _userManager.FindByIdAsync(adminId);

    foreach (var playerId in request.PlayersIds)
    {
      await _squadRepository.AddAsync(new Entities.SquadList()
      {
        MatchId = request.MatchId,
        PlayerId = playerId,
        CreatedOn = DateTime.Now,
        CreatedBy = admin.Id,
      }, cancellationToken);
    }

    await _squadRepository.SaveChangesAsync(cancellationToken);
    return new OkObjectResult(new AdminResponse("Squad list added successfully", ResponseStatus.Success));
  }
}
