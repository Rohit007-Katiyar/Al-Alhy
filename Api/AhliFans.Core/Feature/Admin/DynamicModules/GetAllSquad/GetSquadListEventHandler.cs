using AhliFans.Core.Feature.Admin.DynamicModules.GetAllLegend.Specifications;
using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel.Enum;
using AhliFans.SharedKernel.Interfaces;
using AhliFans.SharedKernel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Entities;
using System.Numerics;
using Microsoft.CodeAnalysis.CSharp;
using AhliFans.DTO;
using AhliFans.SharedKernel.APIServices.Fawry.Model;

namespace AhliFans.Core.Feature.Admin.DynamicModules.GetAllSquad;
public class GetSquadListEventHandler : IRequestHandler<DTO.GetAllGeneralPositionRequest, ActionResult>
{
    private readonly IRepository<Position> _generalPositions;
    private readonly IRepository<Entities.Player> _player;
    List<PlayerListDto> playerListDto = new List<PlayerListDto>();
    private readonly IRepository<Entities.Match> _match;
    public GetSquadListEventHandler(IRepository<Position> generalPositions, IRepository<Entities.Player> player, IRepository<Entities.Match> match)
    {
        _generalPositions = generalPositions;
        _player = player;
        _match = match;
    }
    public async Task<ActionResult> Handle(DTO.GetAllGeneralPositionRequest request, CancellationToken cancellationToken)
    {
        List<Entities.Match> generalPosition1 = await _match.ListAsync(cancellationToken);
        List<Entities.Position> generalPosition = await _generalPositions.ListAsync(cancellationToken);
        List<Entities.Player> player = await _player.ListAsync(cancellationToken);
        PlayerListsDto playerListsDto = new PlayerListsDto();
        PlayerListDto playerListDto = new PlayerListDto();
        foreach (var item in generalPosition)
        {
            switch (item.Name)
            {
                case "GoalKeeper":
                    playerListDto = GetSqadlistData(item, player);
                    playerListDto.playerPosition = item.Name;
                    playerListsDto.playersList.Add(playerListDto);
                    break;
                case "Center Forward":
                    playerListDto = GetSqadlistData(item, player);
                    playerListDto.playerPosition = item.Name;
                    playerListsDto.playersList.Add(playerListDto);
                    break;
                case "Right Wing":
                    playerListDto = GetSqadlistData(item, player);
                    playerListDto.playerPosition = item.Name;
                    playerListsDto.playersList.Add(playerListDto);
                    break;
                case "Left Wing":
                    playerListDto = GetSqadlistData(item, player);
                    playerListDto.playerPosition = item.Name;
                    playerListsDto.playersList.Add(playerListDto);
                    break;
                case "Right Back":
                    playerListDto = GetSqadlistData(item, player);
                    playerListDto.playerPosition = item.Name;
                    playerListsDto.playersList.Add(playerListDto);
                    break;
                case "Left Back":
                    playerListDto = GetSqadlistData(item, player);
                    playerListDto.playerPosition = item.Name;
                    playerListsDto.playersList.Add(playerListDto);
                    break;
                case "Center Back":
                    playerListDto = GetSqadlistData(item, player);
                    playerListDto.playerPosition = item.Name;
                    playerListsDto.playersList.Add(playerListDto);
                    break;
                case "Center Midfielder":
                    playerListDto = GetSqadlistData(item, player);
                    playerListDto.playerPosition = item.Name;
                    playerListsDto.playersList.Add(playerListDto);
                    break;
                case "Defensive Midfielder":
                    playerListDto = GetSqadlistData(item, player);
                    playerListDto.playerPosition = item.Name;
                    playerListsDto.playersList.Add(playerListDto);
                    break;
                case "Attacking Midfielder":
                    playerListDto = GetSqadlistData(item, player);
                    playerListDto.playerPosition = item.Name;
                    playerListsDto.playersList.Add(playerListDto);
                    break;
                default:
                    break;
            }
        }
        if (playerListsDto.playersList.Count == 0) return new BadRequestObjectResult(new AdminResponse("No data yet", ResponseStatus.Error));
        return new OkObjectResult(playerListsDto);
    }

    private PlayerListDto GetSqadlistData(Entities.Position item, List<Entities.Player> player)
    {
        PlayerListDto playerListDto1 = new PlayerListDto();
        foreach (var item1 in player.Where(x => x.PositionId == item.Id))
        {
            PlayerList playerList = new PlayerList();
            playerList.playerName = item1.Name;
            playerList.playerImage = item1.Pic;
            playerList.playerMatchLineUp = item1.Position.Name;
            playerList.playerTshirtImage = null;
            playerListDto1.list.Add(playerList);
        }
        return playerListDto1;
    }
}
