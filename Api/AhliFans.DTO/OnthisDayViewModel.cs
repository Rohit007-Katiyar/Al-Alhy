using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AhliFans.DTO
{
    public class OnthisDayViewModels
    {
        public OnthisDayViewModels()
        {
            events = new List<OnthisDayViewModel>();
        }
        public List<OnthisDayViewModel> events { get; set; }
        public string title = "Three event in this day";
    }
    public class OnthisDayViewModel
    {
        public OnthisDayViewModel()
        {
            bigTrophyViewModel = new BigTrophyViewModel();
            legendBirthdayViewModel = new LegendBirthdayViewModel();
            importantMatchViewModel = new ImportantMatchViewModel();
        }
        public BigTrophyViewModel bigTrophyViewModel { get; set; }
        public LegendBirthdayViewModel legendBirthdayViewModel { get; set; }
        public ImportantMatchViewModel importantMatchViewModel { get; set; }
    }
    public class BigTrophyViewModel
    {
        public BigTrophyViewModel()
        {
            data = new List<BigTrophiesDto>();
        }
        public string Title { get; set; } = "Big Tropies";
        public string Type { get; set; } = "Tropies";
        public List<BigTrophiesDto> data { get; set; }
    }
    public class ImportantMatchViewModel
    {
        public ImportantMatchViewModel()
        {
            data = new List<ImportantMatchResultDto>();
        }
        public string Title { get; set; } = "Important Match Result";
        public string Type { get; set; } = "matchResult";
        public List<ImportantMatchResultDto> data { get; set; }
    }
    public class LegendBirthdayViewModel
    {
        public LegendBirthdayViewModel()
        {
            data = new List<LegendBirthdayDto>();
        }
        public string Title { get; set; } = "Legends Birthdays";
        public string Type { get; set; } = "birthday";
        public List<LegendBirthdayDto> data { get; set; }
    }
    public class ImportantMatchDto
    {
        public TeamDto team1 { get; set; }
        public TeamDto team2 { get; set; }
    }
    public class TeamDto
    {
        public string teamName { get; set; }
        public int? teamScore { get; set; }
        public string logo { get; set; }
    }
    public class BigTrophiesDto
    {
        public DateTime date { get; set; }
        public string matchName { get; set; }
        public string description { get; set; }
        public string imageThumnail { get; set; }
    }
    public class ImportantMatchResultDto : ImportantMatchDto
    {
        public DateTime date { get; set; }
        public DateTime enddate { get; set; }
        public string matchName { get; set; }
        public string teamName2 { get; set; }
        public string description { get; set; }
        public string imageThumnail { get; set; }

    }
    public class LegendBirthdayDto
    {
        public DateTime? birth_date { get; set; }
        public string playerName { get; set; }
        public string? description { get; set; }
        public string imageThumnail { get; set; }

    }
}
