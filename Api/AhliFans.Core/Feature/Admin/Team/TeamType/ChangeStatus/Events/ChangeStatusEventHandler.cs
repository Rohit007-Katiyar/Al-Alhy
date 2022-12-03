using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Team.TeamType.ChangeStatus.Events; 
public class ChangeStatusEventHandler : IRequestHandler<ChangeTeamTypeStatusEvent, ActionResult>
{
  private readonly IRepository<Entities.TeamType> _teamTypeRepository;

  public ChangeStatusEventHandler(IRepository<Entities.TeamType> teamTypeRepository)
  {
    _teamTypeRepository = teamTypeRepository;
  }
  public async Task<ActionResult> Handle(ChangeTeamTypeStatusEvent request, CancellationToken cancellationToken)
  {
    var teamType = await _teamTypeRepository.GetByIdAsync(request.TeamTypeId, cancellationToken);
    if (teamType is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    teamType.IsDeleted = !teamType.IsDeleted;
    await _teamTypeRepository.UpdateAsync(teamType, cancellationToken);
    await _teamTypeRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse(teamType.IsDeleted ? "Delete Team Type Done You Can Retrieve It Any Time" : "Retrieve Team Type Done You Can Delete It Any Time", ResponseStatus.Success));
  }

}
