using System.Globalization;

namespace AhliFans.DTO
{
    public class CalendarViewModel
    {
        public CalendarViewModel()
        {
            todayMatch = new MatchLeagueCalendarViewModel();
            upcomingMatch = new MatchCalendarViewModel();
            eventData = new EventCalendarViewModel();
            birthday = new LegendsBirthdaysDto();
            birthday_stuff = new LegendsBirthdaysDto();
        }
        public MatchLeagueCalendarViewModel todayMatch { get; set; }
        public MatchCalendarViewModel upcomingMatch { get; set; }
        public LegendsBirthdaysDto birthday { get; set; }
        public LegendsBirthdaysDto birthday_stuff { get; set; }
        public EventCalendarViewModel eventData { get; set; }
    }

    public class MatchCalendarViewModel
    {
        public MatchCalendarViewModel()
        {
            matchesList = new List<MatchDetailCalendarViewModel>();
        }
        public DateTime? startDate { get; set; }
        public DateTime? enddate { get; set; }
        public string type { get; set; } = "UpcomingMatch";
        public List<MatchDetailCalendarViewModel> matchesList { get; set; }

    }
    public class MatchDetailCalendarViewModel
    {
        public MatchDetailCalendarViewModel()
        {
            team1 = new TeamDto();
            team2 = new TeamDto();
        }
        public string matchName { get; set; }
        public TeamDto team1 { get; set; }
        public TeamDto team2 { get; set; }
        public string description { get; set; }
        public string imageThumnail { get; set; }
    }

    public class MatchLeagueCalendarViewModel
    {
        public MatchLeagueCalendarViewModel()
        {
            matchesList = new List<MatchDetailLeagueCalendarViewModel>();
        }
        public string title { get; set; } = "Matches";
        public string type { get; set; } = "TodayMatch";
        public List<MatchDetailLeagueCalendarViewModel> matchesList { get; set; }

    }
    public class MatchDetailLeagueCalendarViewModel : MatchDetailCalendarViewModel
    {
        public string? leagueLogo { get; set; }
        public string leagueName { get; set; }
        public DateTime? leagueStartDate { get; set; }
        public string leagueStartTime { get; set; }
        public string timeZone { get; set; }
        public string location { get; set; }
    }

    public class BirthdayCalendarViewModel
    {
        public BirthdayCalendarViewModel()
        {
            data = new List<BirthdayDetailCalendarViewModel>();
        }
        public string title { get; set; }
        public string subtitle { get; set; }
        public byte type { get; set; }
        public List<BirthdayDetailCalendarViewModel> data { get; set; }

    }
    public class BirthdayDetailCalendarViewModel
    {
        public string birth_date { get; set; }
        public string playerName { get; set; }
        public string description { get; set; }
        public string imageThumnail { get; set; }
    }

    public class EventCalendarViewModel
    {
        public EventCalendarViewModel()
        {
            data = new List<EventDetailCalendarViewModel>();
        }
        public string title { get; set; } = "Events";
        public string type { get; set; } = "event";
        public List<EventDetailCalendarViewModel> data { get; set; }

    }
    public class EventDetailCalendarViewModel
    {
        public DateTime event_startdate { get; set; }
        public DateTime event_enddate { get; set; }
        public string location { get; set; }
        public string event_time { get; set; }
        public string eventName { get; set; }
        public string description { get; set; }
        public string imageThumnail { get; set; }
    }

    public class CalendarViewModels
    {
        public CalendarViewModels()
        {
            events = new List<CalendarViewModel>();
        }
        public List<CalendarViewModel> events { get; set; }
    }
}
