using AhliFans.Core.Feature.Admin.Player.Add.Specification;
using AhliFans.Core.Feature.Admin.Player.SocialMediaAccounts.Add.Events;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel.IO.FileManager;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.Add.Events;
public class AddPlayerEventHandler : IRequestHandler<AddPlayerEvent, ActionResult>
{
  private readonly IMediator _mediator;
  private readonly IMapper _mapper;
  private readonly IRepository<Entities.Player> _playerRepository;
  private readonly IFileManager _fileManager;
  public AddPlayerEventHandler(IMediator mediator,IMapper mapper, IRepository<Entities.Player> playerRepository, IFileManager fileManager)
  {
    _mediator = mediator;
    _mapper = mapper;
    _playerRepository = playerRepository;
    _fileManager = fileManager;
  }
  public async Task<ActionResult> Handle(AddPlayerEvent request, CancellationToken cancellationToken)
  {
    if (await _playerRepository.AnyAsync(new IsPlayerNumberExist(request.Number), cancellationToken))
      return new BadRequestObjectResult(new AdminResponse("The same player number exist, Please enter another one",ResponseStatus.Error));

    var player = _mapper.Map<Entities.Player>(request);
    player = await _playerRepository.AddAsync(player, cancellationToken);
    await _playerRepository.SaveChangesAsync(cancellationToken);

    bool saveProfile = await SavePic(request.Pic, player.Id);
    if (!saveProfile) return new OkObjectResult(new AdminResponse("New player has been added successfully,but saving Pic failure .", ResponseStatus.Warning));
    await _mediator.Send(new AddPlayerAccountsEvent(player.Id, request.FaceBookAccount, request.InstaAccount,
      request.TwitterAccount),cancellationToken);
    return new OkObjectResult(new AdminResponse("New player has been added successfully", ResponseStatus.Success));
  }
  private async Task<bool> SavePic(IFormFile? request, int playerId)
  {
    if (request is null)
    {
      return true;
    }
    bool saveProfile = await _fileManager.SaveFileAsync<Entities.Player>(request,
      request.FileName, playerId.ToString());
    return saveProfile;
  }
}
