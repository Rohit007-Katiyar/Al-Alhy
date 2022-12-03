using AhliFans.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhliFans.Core.Feature.Fan.SquadList.GetAll.Dto;
public class AllSquadListDto
{
    public int MatchId { get; set; }
    public string playerMatchLineUp { get; set; }
    public string PlayerImage { get; set; }
    public string PlayerName { get; set; } = string.Empty;
}

public class AllSquadListDtolist
{
    public AllSquadListDtolist()
    {
        list = new List<AllSquadListDto>();
    }
    public string playerPosition { get; set; }
    public List<AllSquadListDto> list { get; set; }
}

public class PlayerListsDtos
{
    public PlayerListsDtos()
    {
        playersList = new List<AllSquadListDtolist>();
    }
    public List<AllSquadListDtolist> playersList { get; }
}