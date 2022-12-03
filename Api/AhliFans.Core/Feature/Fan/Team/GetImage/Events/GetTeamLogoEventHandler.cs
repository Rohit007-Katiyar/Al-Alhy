using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel.IO.FileManager;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Team.GetImage.Events;

public class GetTeamLogoEventHandler : IRequestHandler<GetTeamLogoEvent, ActionResult>
{
  private readonly IRepository<Entities.Team> _teamRepository;
  private readonly IFileManager _fileManager;
  public GetTeamLogoEventHandler(IRepository<Entities.Team> teamRepository, IFileManager fileManager)
  {
    _teamRepository = teamRepository;
    _fileManager = fileManager;
  }
  public async Task<ActionResult> Handle(GetTeamLogoEvent request, CancellationToken cancellationToken)
  {
    var team = await _teamRepository.GetByIdAsync(request.TeamId, cancellationToken);
    if (team is null) return new NotFoundObjectResult(new FanResponse("Not found",ResponseStatus.Error));

    var teamImage = string.IsNullOrEmpty(team.Logo) ?
      await _fileManager.FileProxy<Entities.Team>("defaultTeam.png", "") :
      await _fileManager.FileProxy<Entities.Team>(team.Logo, team.Id.ToString());

    try
    {
      var streamRead = await teamImage.ReadStreamAsync();
      return new FileStreamResult(streamRead, _fileManager.GetContentType(string.IsNullOrEmpty(team.Logo) ? "defaultTeam.png" : team.Logo));
    }
    catch
    {
      return new BadRequestObjectResult(new FanResponse("Can't get the image", ResponseStatus.Error));
    }
  }
}
