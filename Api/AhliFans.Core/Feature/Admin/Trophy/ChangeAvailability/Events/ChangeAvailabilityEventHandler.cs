using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Trophy.ChangeAvailability.Events; 
public class ChangeAvailabilityEventHandler : IRequestHandler<ChangeTrophyAvailabilityEvent, ActionResult>
{
  private readonly IRepository<Entities.Trophy> _trophyRepository;

  public ChangeAvailabilityEventHandler(IRepository<Entities.Trophy> trophyRepository)
  {
    _trophyRepository = trophyRepository;
  }
  public async Task<ActionResult> Handle(ChangeTrophyAvailabilityEvent request, CancellationToken cancellationToken)
  {
    var trophy = await _trophyRepository.GetByIdAsync(request.MatchId, cancellationToken);
    if (trophy is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    trophy.IsAvailable = !trophy.IsAvailable;
    await _trophyRepository.UpdateAsync(trophy, cancellationToken);
    await _trophyRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse(!trophy.IsAvailable ? "Disable Trophy Done You Can Retrieve It Any Time" : "Active Trophy Done You Can Delete It Any Time", ResponseStatus.Success));
  }

}
