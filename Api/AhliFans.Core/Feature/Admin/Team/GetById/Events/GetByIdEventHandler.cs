using AhliFans.Core.Feature.Admin.Team.GetById.DTO;
using AhliFans.Core.Feature.Admin.Team.GetById.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Team.GetById.Events;

public class GetByIdEventHandler : IRequestHandler<GetTeamByIdEvent,ActionResult>
{
  private readonly IRepository<Entities.Team> _teamRepository;

  public GetByIdEventHandler(IRepository<Entities.Team> teamRepository)
  {
    _teamRepository = teamRepository;
  }
  public async Task<ActionResult> Handle(GetTeamByIdEvent request, CancellationToken cancellationToken)
  {
    var team = await _teamRepository.GetBySpecAsync(new GetTeamById(request.TeamId),cancellationToken);
    if (team == null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Success));

    return new OkObjectResult(new TeamDto(team.Id, team.Type.Id.ToString(), request.Lang == Languages.En ? team.Type.Name : team.Type.NameAr,
      team.Region?.Id.ToString()!,request.Lang == Languages.En? team.Region?.Name!:team.Region?.NameAr!, team.Name, team.NameAr));
  }
}
