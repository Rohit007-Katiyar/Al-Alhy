using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Team.TeamType.Add.Events;

public class AddTeamTypeEventHandler : IRequestHandler<AddTeamTypeEvent,ActionResult>
{
  private readonly IRepository<Entities.TeamType> _teamTypeRepository;

  public AddTeamTypeEventHandler(IRepository<Entities.TeamType> teamTypeRepository)
  {
    _teamTypeRepository = teamTypeRepository;
  }
  public async Task<ActionResult> Handle(AddTeamTypeEvent request, CancellationToken cancellationToken)
  {
    var (name, nameAr) = request;
    var teamType = new Entities.TeamType {Name = name, NameAr = nameAr};

    await _teamTypeRepository.AddAsync(teamType,cancellationToken);
    await _teamTypeRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }
}
