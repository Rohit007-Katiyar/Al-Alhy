using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhliFans.DTO
{
    public class PlayerListDto
    {
        public PlayerListDto()
        {
            list = new List<PlayerList>();
        }
        public string playerPosition { get; set; }
        public List<PlayerList> list { get; set; }
    }
    public class PlayerList
    {
        public string playerImage { get; set; }
        public string playerName { get; set; }
        public string playerTshirtImage { get; set; }
        public string playerMatchLineUp { get; set; }
    }

    public class PlayerListsDto
    {
        public PlayerListsDto()
        {
            playersList = new List<PlayerListDto>();
        }
        public List<PlayerListDto> playersList { get; }
    }
}
