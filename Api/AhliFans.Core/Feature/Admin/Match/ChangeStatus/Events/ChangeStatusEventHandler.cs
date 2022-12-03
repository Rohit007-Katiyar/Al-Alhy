using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Match.ChangeStatus.Events; 
public class ChangeStatusEventHandler : IRequestHandler<ChangeMatchStatusEvent, ActionResult>
{
  private readonly IRepository<Entities.Match> _matchRepository;

  public ChangeStatusEventHandler(IRepository<Entities.Match> matchRepository)
  {
    _matchRepository = matchRepository;
  }
  public async Task<ActionResult> Handle(ChangeMatchStatusEvent request, CancellationToken cancellationToken)
  {
    var match = await _matchRepository.GetByIdAsync(request.MatchId, cancellationToken);
    if (match is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    match.IsDeleted = !match.IsDeleted;
    await _matchRepository.UpdateAsync(match, cancellationToken);
    await _matchRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse(match.IsDeleted ? "Delete Match Done You Can Retrieve It Any Time" : "Retrieve Match Done You Can Delete It Any Time", ResponseStatus.Success));
  }

}
