using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.Honor.Edit.Events;

public class EditCoachHonorEventHandler : IRequestHandler<EditCoachHonorEvent,ActionResult>
{
  private readonly IRepository<Entities.Honor> _honorRepository;

  public EditCoachHonorEventHandler(IRepository<Entities.Honor> honorRepository)
  {
    _honorRepository = honorRepository;
  }
  public async Task<ActionResult> Handle(EditCoachHonorEvent request, CancellationToken cancellationToken)
  {
    var honor = await _honorRepository.GetByIdAsync(request.HonorId, cancellationToken);
    if (honor == null) return new NotFoundObjectResult(new AdminResponse("Not found", ResponseStatus.Error));
    
    MapCoachHonor(request, ref honor);
    await _honorRepository.UpdateAsync(honor,cancellationToken);
    await _honorRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }

  private static void MapCoachHonor(EditCoachHonorEvent request,ref Entities.Honor honor)
  {
    honor.CoachId = request.CoachId ?? honor.CoachId;
    honor.TrophyId = request.TrophyId ?? honor.TrophyId;
    honor.IsPersonal = request.IsPersonal ?? honor.IsPersonal;
  }
}
