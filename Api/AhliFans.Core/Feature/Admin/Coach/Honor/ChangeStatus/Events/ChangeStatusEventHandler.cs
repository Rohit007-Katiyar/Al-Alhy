using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.Honor.ChangeStatus.Events;

public class ChangeStatusEventHandler:IRequestHandler<ChangeCoachHonorStatusEvent, ActionResult>
{
  private readonly IRepository<Entities.Honor> _honorRepository;

  public ChangeStatusEventHandler(IRepository<Entities.Honor> honorRepository)
  {
    _honorRepository = honorRepository;
  }
  public async Task<ActionResult> Handle(ChangeCoachHonorStatusEvent request, CancellationToken cancellationToken)
  {
    var honor = await _honorRepository.GetByIdAsync(request.HonorId, cancellationToken);
    if (honor is null) return new NotFoundObjectResult(new AdminResponse("Not found", ResponseStatus.Error));
    
    honor.IsDeleted = !honor.IsDeleted;
    await _honorRepository.UpdateAsync(honor, cancellationToken);
    await _honorRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse(honor.IsDeleted ? "Delete Honor Done You Can Retrieve It Any Time" : "Retrieve Honor Done You Can Delete It Any Time", ResponseStatus.Success));
  }
}
