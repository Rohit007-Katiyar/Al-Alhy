using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Team.ChangeStatus.Events; 
public class ChangeStatusEventHandler : IRequestHandler<ChangeTeamStatusEvent, ActionResult>
{
  private readonly IRepository<Entities.Team> _teamRepository;

  public ChangeStatusEventHandler(IRepository<Entities.Team> teamRepository)
  {
    _teamRepository = teamRepository;
  }
  public async Task<ActionResult> Handle(ChangeTeamStatusEvent request, CancellationToken cancellationToken)
  {
    var teamType = await _teamRepository.GetByIdAsync(request.TeamId, cancellationToken);
    if (teamType is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    teamType.IsDeleted = !teamType.IsDeleted;
    await _teamRepository.UpdateAsync(teamType, cancellationToken);
    await _teamRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse(teamType.IsDeleted ? "Delete Team Done You Can Retrieve It Any Time" : "Retrieve Team Done You Can Delete It Any Time", ResponseStatus.Success));
  }

}
