using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.ChangeStatus.Events;

public class ChangeStatusEventHandler:IRequestHandler<ChangeCoachStatusEvent, ActionResult>
{
  private readonly IRepository<Entities.Coach> _coachRepository;

  public ChangeStatusEventHandler(IRepository<Entities.Coach> coachRepository)
  {
    _coachRepository = coachRepository;
  }
  public async Task<ActionResult> Handle(ChangeCoachStatusEvent request, CancellationToken cancellationToken)
  {
    var coach = await _coachRepository.GetByIdAsync(request.CoachId, cancellationToken);
    if (coach is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));
    
    coach.IsDeleted = !coach.IsDeleted;
    await _coachRepository.UpdateAsync(coach, cancellationToken);
    await _coachRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse(coach.IsDeleted ? "Delete Coach Done You Can Retrieve It Any Time" : "Retrieve Coach Done You Can Delete It Any Time", ResponseStatus.Success));
  }
}
