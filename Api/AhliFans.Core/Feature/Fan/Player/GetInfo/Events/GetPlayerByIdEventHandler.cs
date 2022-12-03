using AhliFans.Core.Feature.Fan.Player.GetInfo.DTO;
using AhliFans.Core.Feature.Fan.Player.GetInfo.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Player.GetInfo.Events;
public class GetPlayerByIdEventHandler : IRequestHandler<GetPlayerByIdEvent,ActionResult>
{
  private readonly IRepository<Entities.Player> _playerRepository;
  public GetPlayerByIdEventHandler(IRepository<Entities.Player> playerRepository)
  {
    _playerRepository = playerRepository;
  }
  public async Task<ActionResult> Handle(GetPlayerByIdEvent request, CancellationToken cancellationToken)
  {
    var player = await _playerRepository.GetBySpecAsync(new GetPlayerById(request.PlayerId),cancellationToken);
    if (player == null) return new NotFoundObjectResult(new FanResponse("Not found", ResponseStatus.Error));

    return new OkObjectResult(new PlayerInfoDto(player.Id, request.Language == Languages.En ? player.Position?.Name!: player.Position?.NameAr!, player.Number,request.Language == Languages.En? player.Name:player.NameAr,
      player.BirthDate?.ToString("MM/dd/yyyy")!,DateTime.Now.Year - (player.BirthDate?.Year ?? 1), player.Height, player.Weight, request.Language == Languages.En ? player.Biography:player.BiographyAr,
      request.Language == Languages.En ? player.CityOfBirth?.Country.Name!:player.CityOfBirth?.Country.NameAr!,
      request.Language == Languages.En ?player.CityOfBirth?.Name!:player.CityOfBirth?.NameAr!,player.IsDeleted,player.DateSigned?.ToString("MM/dd/yyyy")!,
      request.Language == Languages.En?player.Country?.Name!:player.Country?.NameAr!));
  }
}
