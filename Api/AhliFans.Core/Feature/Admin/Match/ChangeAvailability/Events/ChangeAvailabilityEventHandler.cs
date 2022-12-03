using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Match.ChangeAvailability.Events; 
public class ChangeAvailabilityEventHandler : IRequestHandler<ChangeMatchAvailabilityEvent, ActionResult>
{
  private readonly IRepository<Entities.Match> _matchRepository;

  public ChangeAvailabilityEventHandler(IRepository<Entities.Match> matchRepository)
  {
    _matchRepository = matchRepository;
  }
  public async Task<ActionResult> Handle(ChangeMatchAvailabilityEvent request, CancellationToken cancellationToken)
  {
    var match = await _matchRepository.GetByIdAsync(request.MatchId, cancellationToken);
    if (match is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    match.IsAvailable = !match.IsAvailable;
    await _matchRepository.UpdateAsync(match, cancellationToken);
    await _matchRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse(!match.IsAvailable ? "Disable Match Done You Can Retrieve It Any Time" : "Active Match Done You Can Delete It Any Time", ResponseStatus.Success));
  }

}
