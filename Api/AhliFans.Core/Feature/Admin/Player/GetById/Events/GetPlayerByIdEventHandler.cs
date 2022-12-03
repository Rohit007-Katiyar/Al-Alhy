using AhliFans.Core.Feature.Admin.Player.GetById.DTO;
using AhliFans.Core.Feature.Admin.Player.GetById.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.GetById.Events;
public class GetPlayerByIdEventHandler : IRequestHandler<GetPlayerByIdEvent, ActionResult>
{
  private readonly IRepository<Entities.Player> _playerRepository;
  public GetPlayerByIdEventHandler(IRepository<Entities.Player> playerRepository)
  {
    _playerRepository = playerRepository;
  }
  public async Task<ActionResult> Handle(GetPlayerByIdEvent request, CancellationToken cancellationToken)
  {
    var player = await _playerRepository.GetBySpecAsync(new GetPlayerById(request.PlayerId), cancellationToken);
    if (player == null) return new BadRequestObjectResult(new AdminResponse("Not found", ResponseStatus.Error));

    var teamCategoryName = request.Language == Languages.Ar ? player.TeamCategory?.NameAr ?? string.Empty : player.TeamCategory?.Name ?? string.Empty;

    return new OkObjectResult(new PlayerInfoDto(player.Id, player.Position?.Id.ToString()!,
       request.Language == Languages.En ? player.Position?.Name : player.Position?.NameAr
      , player.Number, player.Name, player.NameAr,
      player.BirthDate, player.Height, player.Weight, player.Biography, player.BiographyAr,
       player.CityOfBirth?.Country?.Id.ToString()!, player.CityOfBirth?.Id.ToString(), player.IsDeleted, player.DateSigned,
      player.Country?.Id.ToString(), player.TeamCategoryId, teamCategoryName));
  }
}
