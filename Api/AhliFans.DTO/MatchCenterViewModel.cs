using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhliFans.DTO
{
    public class MatchCenterViewModel : AllSquadListDtolist1
    {
        public MatchCenterViewModel()
        {

            team1 = new TeamDto();
            team2 = new TeamDto();
            public PlayerListsDtos1()
            {
                playersList = new List<AllSquadListDtolist1>();
            }
        }

        public string title { get; set; }
        public string type { get; set; }
        public string leagueLogo { get; set; }
        public string leagueName { get; set; }
        public string leagueStartDate { get; set; }
        public string leagueStartTime { get; set; }
        public string timeZone { get; set; }
        public TeamDto team1 { get; set; }
        public TeamDto team2 { get; set; }
        public string location { get; set; }
        public string imageStadium { get; set; }
        public string startingLineUpImage { get; set; }
        public List<AllSquadListDtolist1> playersList { get; }
    }


    public class AllSquadListDto1
    {
        public int MatchId { get; set; }
        public string playerMatchLineUp { get; set; }
        public string PlayerImage { get; set; }
        public string PlayerName { get; set; } = string.Empty;
    }

    public class AllSquadListDtolist1
    {
        public AllSquadListDtolist1()
        {
            list = new List<AllSquadListDto1>();
        }
        public string playerPosition { get; set; }
        public List<AllSquadListDto1> list { get; set; }
    }

    public class PlayerListsDtos1
    {
        public PlayerListsDtos1()
        {
            playersList = new List<AllSquadListDtolist1>();
        }
        public List<AllSquadListDtolist1> playersList { get; }
    }
}
