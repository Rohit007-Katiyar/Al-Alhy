using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Fan.SquadList.Get.Dto;
using AhliFans.Core.Feature.Fan.SquadList.Get.Specifications;
using AhliFans.Core.Feature.Fan.SquadList.GetAll.Dto;
using AhliFans.Core.Feature.Fan.SquadList.GetAll.Specifications;
using AhliFans.Core.Feature.Localization;
using AhliFans.DTO;
using AhliFans.SharedKernel.APIServices.Fawry.Model;
using AhliFans.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhliFans.Core.Feature.Fan.SquadList.GetAll.Events;
public class GetAllSquadListEventHandler : IRequestHandler<GetAllSquadListEvent, ActionResult>
{
    private readonly IRepository<Entities.SquadList> _repository;

    public GetAllSquadListEventHandler(IRepository<Entities.SquadList> repository)
    {
        _repository = repository;
    }

    public async Task<ActionResult> Handle(GetAllSquadListEvent request, CancellationToken cancellationToken)
    {
        var squadList = await _repository.ListAsync(new GetAllSquadListByMatchIdAndGeneralPosition(), cancellationToken);
        var isArabic = request.Language == Languages.Ar;
        PlayerListsDtos playerListsDtos = new PlayerListsDtos();

        var da = squadList.GroupBy(x => x.Player?.Position?.GeneralPosition?.Name);
        foreach (var d in da)
        {
            AllSquadListDtolist allSquadListDtolist = new AllSquadListDtolist();
            allSquadListDtolist.playerPosition = d.Key ?? string.Empty;
            foreach (var a in d)
            {
                AllSquadListDto allSquadListDto = new AllSquadListDto();
                allSquadListDto.MatchId = a.MatchId;
                allSquadListDto.PlayerImage = a.Player.Pic ?? string.Empty;
                allSquadListDto.PlayerName = a.Player.Name ?? string.Empty;
                allSquadListDto.playerMatchLineUp = a.Player.Position.Name;
                allSquadListDtolist.list.Add(allSquadListDto);
            }
            playerListsDtos.playersList.Add(allSquadListDtolist);
        }
        return new OkObjectResult(playerListsDtos);
    }
}