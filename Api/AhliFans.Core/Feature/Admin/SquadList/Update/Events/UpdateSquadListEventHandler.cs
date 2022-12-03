using AhliFans.Core.Feature.Admin.SquadList.Update.Specifications;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.SquadList.Update.Events;

public class UpdateSquadListEventHandler : IRequestHandler<UpdateSquadListEvent, ActionResult>
{
  private readonly IRepository<Entities.SquadList> _repository;

  private readonly IValidator<UpdateSquadListEvent> _validator;

  private readonly UserManager<Security.Entities.Admin> _userManager;

  private readonly IHttpContextAccessor _httpContextAccessor;

  public UpdateSquadListEventHandler(IRepository<Entities.SquadList> repository, IValidator<UpdateSquadListEvent> validator, UserManager<Security.Entities.Admin> userManager, IHttpContextAccessor httpContextAccessor)
  {
    _repository = repository;
    _validator = validator;
    _userManager = userManager;
    _httpContextAccessor = httpContextAccessor;
  }

  public async Task<ActionResult> Handle(UpdateSquadListEvent request, CancellationToken cancellationToken)
  {
    var validationResult = await _validator.ValidateAsync(request, cancellationToken);
    if (!validationResult.IsValid)
    {
      var errorResponse = new AdminResponse(string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)), SharedKernel.Enum.ResponseStatus.Error);
      return new BadRequestObjectResult(errorResponse);
    }

    var adminId = _httpContextAccessor.HttpContext.User.Claims.First(c => c.Type == "User Id").Value;
    var admin = await _userManager.FindByIdAsync(adminId);

    var squadLists = await _repository.ListAsync(new GetSquadListsByMatchId(request.MatchId), cancellationToken);

    await _repository.DeleteRangeAsync(squadLists, cancellationToken);

    var newSquadLists = request.PlayersIds.Select(pId =>
    {
      return new Entities.SquadList()
      {
        MatchId = request.MatchId,
        PlayerId = pId,
        ModifiedBy = admin.Id,
        ModifiedOn = DateTime.Now,
        CreatedBy = admin.Id,
        CreatedOn = DateTime.Now
      };
    });

    foreach (var squadList in newSquadLists)
    {
      await _repository.AddAsync(squadList, cancellationToken);
    }

    await _repository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("Updated successfully", SharedKernel.Enum.ResponseStatus.Success));
  }
}
