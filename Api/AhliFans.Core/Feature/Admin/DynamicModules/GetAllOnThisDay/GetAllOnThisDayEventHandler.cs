using AhliFans.Core.Feature.Entities;
using AhliFans.DTO;
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

namespace AhliFans.Core.Feature.Admin.DynamicModules.GetAllOnThisDay;

public class GetAllOnThisDayEventHandler //: IRequestHandler<DTO.GetOnThisDayById, ActionResult>
{
    //private readonly IRepository<Entities.DynamicModules> _DynamicModulesRepo;
    //public GetAllOnThisDayEventHandler(IRepository<Entities.DynamicModules> DynamicModulesRepo)
    //{
    //    _DynamicModulesRepo = DynamicModulesRepo;
    //}
    //public async Task<ActionResult> Handle(DTO.GetOnThisDayById request, CancellationToken cancellationToken)
    //{
    //    var dynamicModules = await _DynamicModulesRepo.ListAsync();
    //    if (dynamicModules.Count == 0) return new BadRequestObjectResult(new AdminResponse("Not Data", ResponseStatus.Error));

    //    dynamicModulesdata = dynamicModules.Where(m => m.ModuleType == request.ModuleType).ToList();
    //}

    //private List<PlayerListDto> GetSqadlistData(Entities.Position item, List<Entities.Player> player)
    //{

    //    PlayerListDto playerListDto1 = new PlayerListDto();
    //    playerListDto1.playerPosition = item.Name;
    //    playerListDto.Add(playerListDto1);
    //    foreach (var item1 in player.Where(x => x.PositionId == item.Id))
    //    {
    //        PlayerList playerList = new PlayerList();
    //        playerList.playerName = item1.Name;
    //        playerList.playerImage = item1.Pic;
    //        playerList.playerMatchLineUp = item1.Position.Name;
    //        playerList.playerTshirtImage = null;
    //        playerListDto1.playerLists.Add(playerList);
    //    }
    //    return playerListDto;
    //}
}

