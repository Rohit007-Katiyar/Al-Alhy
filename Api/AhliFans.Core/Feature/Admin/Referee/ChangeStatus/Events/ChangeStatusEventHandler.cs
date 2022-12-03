using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Referee.ChangeStatus.Events; 
public class ChangeStatusEventHandler : IRequestHandler<ChangeRefereeStatusEvent, ActionResult>
{
  private readonly IRepository<Entities.Referee> _refereeRepository;

  public ChangeStatusEventHandler(IRepository<Entities.Referee> refereeRepository)
  {
    _refereeRepository = refereeRepository;
  }
  public async Task<ActionResult> Handle(ChangeRefereeStatusEvent request, CancellationToken cancellationToken)
  {
    var referee = await _refereeRepository.GetByIdAsync(request.RefereeId, cancellationToken);
    if (referee is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    referee.IsDeleted = !referee.IsDeleted;
    await _refereeRepository.UpdateAsync(referee, cancellationToken);
    await _refereeRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse(referee.IsDeleted ? "Delete Referee Done You Can Retrieve It Any Time" : "Retrieve Referee Done You Can Delete It Any Time", ResponseStatus.Success));
  }

}
