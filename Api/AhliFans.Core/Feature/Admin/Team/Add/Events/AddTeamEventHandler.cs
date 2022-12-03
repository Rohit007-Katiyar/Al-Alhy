using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel.IO.FileManager;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Team.Add.Events;

public class AddTeamEventHandler : IRequestHandler<AddTeamEvent,ActionResult>
{
  private readonly IRepository<Entities.Team> _teamRepository;
  private readonly IMapper _mapper;
  private readonly IFileManager _fileManager;
  public AddTeamEventHandler(IRepository<Entities.Team> teamRepository,IMapper mapper, IFileManager fileManager)
  {
    _teamRepository = teamRepository;
    _mapper = mapper;
    _fileManager = fileManager;
  }
  public async Task<ActionResult> Handle(AddTeamEvent request, CancellationToken cancellationToken)
  {
    var team = _mapper.Map<Entities.Team>(request);

    await _teamRepository.AddAsync(team, cancellationToken);
    await _teamRepository.SaveChangesAsync(cancellationToken);

    bool saveProfile = await SavePic(request.Logo, team.Id);
    if (!saveProfile) return new OkObjectResult(new AdminResponse("New Team has been added successfully,but saving logo failure .", ResponseStatus.Warning));
    
    return new OkObjectResult(new AdminResponse("Operation done successfully", ResponseStatus.Success));
  }
  private async Task<bool> SavePic(IFormFile? request, int teamId)
  {
    if (request is null)
    {
      return true;
    }
    bool saveProfile = await _fileManager.SaveFileAsync<Entities.Team>(request,
      request.FileName, teamId.ToString());
    return saveProfile;
  }
}
