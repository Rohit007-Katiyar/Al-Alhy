using AhliFans.Core.Feature.Admin.Player.SocialMediaAccounts.Edit.Events;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.Update.Events;

public class UpdatePlayerEventHandler:IRequestHandler<UpdatePlayerEvent, ActionResult>
{
  private readonly IMediator _mediator;
  private readonly IRepository<Entities.Player>  _playerRepository;
  public UpdatePlayerEventHandler(IMediator mediator,IRepository<Entities.Player> playerRepository)
  {
    _mediator = mediator;
    _playerRepository = playerRepository;
  }

  public async Task<ActionResult> Handle(UpdatePlayerEvent request, CancellationToken cancellationToken)
  {
    if (request.BirthDate is not null && request.BirthDate > DateTime.Now)
      return new BadRequestObjectResult(new AdminResponse("Not Valid Birth Date", ResponseStatus.Error));
    
    if (request.DateSigned is not null && request.DateSigned > DateTime.Now)
          return new BadRequestObjectResult(new AdminResponse("Not Valid Signed Date", ResponseStatus.Error));

    var player = await _playerRepository.GetByIdAsync(request.PlayerId, cancellationToken);
    if (player is null) return new BadRequestObjectResult(new AdminResponse("Not Found", ResponseStatus.Error));

    MapPlayer(request,ref player);
    await _playerRepository.UpdateAsync(player,cancellationToken);
    await _playerRepository.SaveChangesAsync(cancellationToken);
    await _mediator.Send(new EditPlayerAccountEvent(player.Id, request.FaceBookAccount, request.InstaAccount,
      request.TwitterAccount),cancellationToken);
    return new OkObjectResult(new AdminResponse("Operation done successfully.", ResponseStatus.Success));
  }

  private static void MapPlayer(UpdatePlayerEvent request,ref  Entities.Player player)
  {
    player.PositionId = request.PositionId ?? player.PositionId;
    player.Number = request.Number ?? player.Number;
    player.Name = request.Name ?? player.Name;
    player.NameAr = request.NameAr ?? player.NameAr;
    player.BirthDate = request.BirthDate ?? player.BirthDate;
    player.DateSigned = request.DateSigned ?? player.DateSigned;
    player.Height = request.Height ?? player.Height;
    player.Weight = request.Weight ?? player.Weight;
    player.Biography = request.Biography ?? player.Biography;
    player.BiographyAr = request.BiographyAr ?? player.BiographyAr;
    player.CityOfBirthId = request.CityOfBirth ?? player.CityOfBirthId;
    player.TeamCategoryId = request.TeamCategoryId ?? player.TeamCategoryId;
  }
}
