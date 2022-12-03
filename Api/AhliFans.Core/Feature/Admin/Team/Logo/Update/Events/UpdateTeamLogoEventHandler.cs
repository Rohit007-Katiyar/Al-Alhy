using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel.IO.FileManager;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Team.Logo.Update.Events;

public class UpdateTeamLogoEventHandler : IRequestHandler<UpdateTeamLogoEvent, ActionResult>
{
  private readonly IFileManager _fileManager;
  private readonly IRepository<Entities.Team> _teamRepository;
  public UpdateTeamLogoEventHandler(IFileManager fileManager, IRepository<Entities.Team> trophyRepository)
  {
    _fileManager = fileManager;
    _teamRepository = trophyRepository;
  }
  public async Task<ActionResult> Handle(UpdateTeamLogoEvent request, CancellationToken cancellationToken)
  {
    var team = await _teamRepository.GetByIdAsync(request.TeamId,cancellationToken);
    if (team is null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));
    
    bool image = await UpdateImageAsync(request, team);
    if (!image)
    {
      return new OkObjectResult(new AdminResponse("Failed to upload logo to server", ResponseStatus.Warning));
    }
    team.Logo = request.TeamLogo.FileName;
    await _teamRepository.UpdateAsync(team,cancellationToken);
    await _teamRepository.SaveChangesAsync(cancellationToken);

    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }

  private Task<bool> UpdateImageAsync(UpdateTeamLogoEvent request, Entities.Team? team)
  {
    return _fileManager.UpdateFileAsync<Entities.Team>(request.TeamLogo, team?.Logo!, request.TeamLogo.FileName,
      team?.Id.ToString()!);
  }
}
