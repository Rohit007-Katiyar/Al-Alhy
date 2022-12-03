using AhliFans.Core.Feature.Entities;
using AhliFans.Core.Feature.Enums;
using Microsoft.EntityFrameworkCore;
namespace AhliFans.Infrastructure.Seeds.Preferences;

public static class PreferencesSeeds
{
  public static void InitializeSeeds(this ModelBuilder modelBuilder)
  {
    #region Regions
    modelBuilder.Entity<Region>().HasData(
      new Region() {Id = 1, NameAr = "محلي", Name = "Local"},
      new Region() {Id = 2, NameAr = "افريقي", Name = "African"},
      new Region() {Id = 3, NameAr = "دولي", Name = "International"});
    #endregion
    #region GeneralPosition
    modelBuilder.Entity<GeneralPlayerPosition>().HasData(
      new GeneralPlayerPosition() { Id = 1, NameAr = "حراس المرمي", Name = "Goalkeepers" },
      new GeneralPlayerPosition() { Id = 2, NameAr = "مدافعين", Name = "Defenders" },
      new GeneralPlayerPosition() { Id = 3, NameAr = "وسط ملعب", Name = "Midfielder" },
      new GeneralPlayerPosition() { Id = 4, NameAr = "مهاجمين", Name = "Attackers" }
    );
    #endregion
    #region Country
    modelBuilder.Entity<Country>().HasData(
      new Country() { Id = 1, NameAr = "مصر", Name = "Egypt" }
    );
    #endregion
    #region League
    modelBuilder.Entity<League>().HasData(
        new League() { Id = 1, Name = "League Championship", NameAr = "بطوله الدوري", Date = DateTime.Parse("8/10/2019") }
      );

      modelBuilder.Entity<LeagueDates>().HasData(
        new LeagueDates() { Id = 1, Year = 2012, LeagueId = 1 },
        new LeagueDates() { Id = 2, Year = 2018, LeagueId = 1 },
        new LeagueDates() { Id = 3, Year = 2020, LeagueId = 1 }
      );
    #endregion
    #region City
      modelBuilder.Entity<City>().HasData(
        new City() { Id = 1, CountryId = 1, NameAr = "القاهرة", Name = "Cairo" },
        new City() { Id = 2, CountryId = 1, NameAr = "القليوبية", Name = "Al-Qalyubia" },
        new City() { Id = 3, CountryId = 1, NameAr = "الجيزة", Name = "Giza" }
      );
    #endregion
    #region MyRegion
    modelBuilder.Entity<Referee>().HasData(
        new Referee() { Id = 1,NationalityId = 1, Name = "Gehad Gresha", NameAr = "جهاد جريشه", Date = DateTime.Parse("2/6/2020") }
      );
    #endregion
    #region Season
    modelBuilder.Entity<Season>().HasData(
        new Season() { Id = 1, Name = "Egyptian League", NameAr = "الدوري المصري", StartDate = DateTime.Parse("2/10/2019"), EndDate = DateTime.Parse("2/6/2020"), CreationDate = DateTime.Parse("2/6/2020") }
      );
    #endregion
    #region Stadium
    modelBuilder.Entity<Stadium>().HasData(
        new Stadium() { Id = 1, Name = "Cairo International Stadium", NameAr = "استاد القاهره الدولي", Date = DateTime.Parse("2/6/2020") }
      );
    #endregion
    #region Trophy
    modelBuilder.Entity<TrophyType>().HasData(
        new TrophyType() { Id = 1, Date = DateTime.Parse("2/6/2020"), Name = "Local Trophy", NameAr = "ذكري محلية" },
        new TrophyType() { Id = 2, Date = DateTime.Parse("2/6/2020"), Name = "African Trophy", NameAr = "ذكري افريقية" }
      );

      modelBuilder.Entity<Trophy>().HasData(
        new Trophy() { Id = 1, CreatedOn = DateTime.Parse("2/6/2020"), Name = "Egyptian League", NameAr = "الدوري المصري", TrophyTypeId = 1 },
        new Trophy() { Id = 2, CreatedOn = DateTime.Parse("2/6/2020"), Name = "African Cup", NameAr = "دوري ابطال افريقيا", TrophyTypeId = 2 }
      );
    #endregion
    #region Team
    modelBuilder.Entity<TeamType>().HasData(
        new TeamType() { Id = 1, Name = "Egyptian Team", NameAr = "فريق مصري" }
      );

      modelBuilder.Entity<Team>().HasData(
        new Team() { Id = 1, Name = "El Zamalek", NameAr = "الزمالك", TypeId = 1, Date = DateTime.Parse("2/6/2020") },
        new Team() { Id = 2, Name = "El Asmaily", NameAr = "الاسماعيلي", TypeId = 1, Date = DateTime.Parse("2/6/2020") },
        new Team() { Id = 3, Name = "El Masry", NameAr = "المصري", TypeId = 1, Date = DateTime.Parse("2/6/2020") }
      );
    #endregion
    #region Players
      modelBuilder.Entity<Position>().HasData(
        new Position() { Id = 1, Date = DateTime.Parse("2/6/2020"), Name = "GoalKeeper", NameAr = "حارس مرمي", Symbol = "GK" ,GeneralPositionId = 1},
        new Position() { Id = 2, Date = DateTime.Parse("2/6/2020"), Name = "Center Forward", NameAr = "مهاجم", Symbol = "CF" ,GeneralPositionId = 4},
        new Position() { Id = 3, Date = DateTime.Parse("2/6/2020"), Name = "Right Wing", NameAr = "جناح ايمن", Symbol = "RW" ,GeneralPositionId = 4},
        new Position() { Id = 4, Date = DateTime.Parse("2/6/2020"), Name = "Left Wing", NameAr = "جناح ايسر", Symbol = "LW" ,GeneralPositionId = 4},
        new Position() { Id = 5, Date = DateTime.Parse("2/6/2020"), Name = "Right Back", NameAr = "مدافع ايمن", Symbol = "RB" ,GeneralPositionId = 2},
        new Position() { Id = 6, Date = DateTime.Parse("2/6/2020"), Name = "Left Back", NameAr = "مدافع ايسر", Symbol = "LB" ,GeneralPositionId = 2},
        new Position() { Id = 7, Date = DateTime.Parse("2/6/2020"), Name = "Center Back", NameAr = "قلب دفاع", Symbol = "CB" ,GeneralPositionId = 2},
        new Position() { Id = 8, Date = DateTime.Parse("2/6/2020"), Name = "Center Midfielder", NameAr = "وسط ملعب", Symbol = "CM" ,GeneralPositionId = 3},
        new Position() { Id = 9, Date = DateTime.Parse("2/6/2020"), Name = "Defensive Midfielder", NameAr = "وسط مدافع", Symbol = "DM" ,GeneralPositionId = 3},
        new Position() { Id = 10, Date = DateTime.Parse("2/6/2020"), Name = "Attacking Midfielder", NameAr = "وسط مهاجم", Symbol = "AM" ,GeneralPositionId = 3}
      );

      modelBuilder.Entity<Player>().HasData(
        new Player() {Id = 1, Name = "Mohamed El-Shinawy", NameAr = "محمد الشناوي", PositionId = 1, Number = 1, Date = DateTime.Parse("2/6/2020"), DateSigned = DateTime.Parse("1/5/2019"), BirthDate = DateTime.Parse("12/18/1988"), CountryHeLiveIn = 1, CityOfBirthId = 1, Height = 191, Weight = 86, Pic = "shinawy.png" ,Biography = "He is Egypt's best goalkeeper and was raised in Al Ahly as one of our homegrown players." +
          "He left the club to gain more experience and playtime in different Egyptian teams." +
          "After his great performance, he rejoined Al Ahly and proved himself as one of the top goalkeepers in Egypt. " +
          "El Shenawy represented our national team in 2018 World Cup after his second season with AlAhly."},
        new Player() {Id = 2,Name = "Ali Malol", NameAr = "علي معلول", PositionId = 5, Number = 11, Date = DateTime.Parse("2/6/2020"), DateSigned = DateTime.Parse("2/6/2020"), BirthDate = DateTime.Parse("12/18/1988"), CountryHeLiveIn = 1, CityOfBirthId = 1, Height = 170, Weight = 71 , Pic = "malol.png" },
        new Player() {Id = 3,Name = "Percy Tau", NameAr = "بيرسي تاو", PositionId = 3, Number = 23, Date = DateTime.Parse("2/6/2020"), DateSigned = DateTime.Parse("2/6/2020"), BirthDate = DateTime.Parse("5/13/1994"), CountryHeLiveIn = 1, CityOfBirthId = 1, Height = 170, Weight = 71 },
        new Player() {Id = 4,Name = "Ahmed Abd-Elqader", NameAr = "أحمد القادر", PositionId = 4, Number = 35, Date = DateTime.Parse("2/6/2020"), DateSigned = DateTime.Parse("2/6/2020"), BirthDate = DateTime.Parse("5/13/1994"), CountryHeLiveIn = 1, CityOfBirthId = 1, Height = 170, Weight = 71 },
        new Player() {Id = 5,Name = "Mohamed Sherif", NameAr = "محمد شريف", PositionId = 2, Number = 10, Date = DateTime.Parse("2/6/2020"), DateSigned = DateTime.Parse("2/6/2020"), BirthDate = DateTime.Parse("5/13/1994"), CountryHeLiveIn = 1, CityOfBirthId = 1, Height = 170, Weight = 71 },
        new Player() {Id = 6,Name = "Hamdi Fathy", NameAr = "حمدي فتحي", PositionId = 8, Number = 8, Date = DateTime.Parse("2/6/2020"), DateSigned = DateTime.Parse("2/6/2020"), BirthDate = DateTime.Parse("5/13/1994"), CountryHeLiveIn = 1, CityOfBirthId = 1, Height = 170, Weight = 71 },
        new Player() {Id = 7,Name = "Yasser Ibrahim", NameAr = "ياسر إبراهيم", PositionId = 7, Number = 6, Date = DateTime.Parse("2/6/2020"), DateSigned = DateTime.Parse("2/6/2020"), BirthDate = DateTime.Parse("5/13/1994"), CountryHeLiveIn = 1, CityOfBirthId = 1, Height = 170, Weight = 71 },
        new Player() {Id = 8,Name = "Rami Rabiea", NameAr = "رامي ربيعة", PositionId = 7, Number = 5, Date = DateTime.Parse("2/6/2020"), DateSigned = DateTime.Parse("2/6/2020"), BirthDate = DateTime.Parse("5/13/1994"), CountryHeLiveIn = 1, CityOfBirthId = 1, Height = 170, Weight = 71 },
        new Player() {Id = 9,Name = "Mohamed Hany", NameAr = "محمد هاني", PositionId = 6, Number = 30, Date = DateTime.Parse("2/6/2020"), DateSigned = DateTime.Parse("2/6/2020"), BirthDate = DateTime.Parse("5/13/1994"), CountryHeLiveIn = 1, CityOfBirthId = 1, Height = 170, Weight = 71 },
        new Player() {Id = 10,Name = "Amr Al-Sulayya", NameAr = "عمرو السولية", PositionId = 9, Number = 17, Date = DateTime.Parse("2/6/2020"), DateSigned = DateTime.Parse("2/6/2020"), BirthDate = DateTime.Parse("5/13/1994"), CountryHeLiveIn = 1, CityOfBirthId = 1, Height = 170, Weight = 71 },
        new Player() {Id = 11,Name = "Magdy Qafsha", NameAr = "محمد مجدي قفشه", PositionId = 10, Number = 19, Date = DateTime.Parse("2/6/2020"), DateSigned = DateTime.Parse("2/6/2020"), BirthDate = DateTime.Parse("5/13/1994"), CountryHeLiveIn = 1, CityOfBirthId = 1, Height = 170, Weight = 71 }
      );
    #endregion
    #region Coach
    modelBuilder.Entity<Title>().HasData(
      new Title() { Id = 1,Date = DateTime.Parse("2/6/2020"), Text = "Coach", TextAr = "مدير فني" },
      new Title() { Id = 2,Date = DateTime.Parse("2/6/2020"), Text = "Football Manager", TextAr = "مدير كرة القدم" }
    );

    modelBuilder.Entity<Coach>().HasData(
      new Coach() { Id = 1,TitleId = 1,CityId = 1,CountryId = 1,FirstName = "Pitso", FirstNameAr = "بيتسو", LastName = "Mosimane", LastNameAr = "موسيماني", Date = DateTime.Parse("2/6/2020"), DateSigned = DateTime.Parse("8/10/2019"), BirthDate = DateTime.Parse("2/10/1960"), IsCurrent = false,Pic = "pitso-mosimane.png" },
      new Coach() { Id = 2,TitleId = 1,CityId = 1,CountryId = 1,FirstName = "Ricardo", FirstNameAr = "ريكاردو", LastName = "Suarez", LastNameAr = "سواريز", Date = DateTime.Parse("2/6/2020"), DateSigned = DateTime.Parse("8/10/2022"), BirthDate = DateTime.Parse("2/10/1960"), IsCurrent = true},
      new Coach() { Id = 3,TitleId = 2,CityId = 1,CountryId = 1,FirstName = "Syed ", FirstNameAr = "سيد", LastName = "Abdul Hafeez", LastNameAr = "عبد الحفيظ", Date = DateTime.Parse("2/6/2020"), DateSigned = DateTime.Parse("8/10/2022"), BirthDate = DateTime.Parse("2/10/1960"), IsCurrent = true}
    );

    #endregion
    #region Match
    modelBuilder.Entity<Match>().HasData(
      new Match() { Id = 1, MatchType = MatchTypes.History, Date = DateTime.Parse("2/6/2020"), SeasonId = 1,OpponentTeamId = 1,StadiumId = 1,RefereeId = 1,IsAway = false,Time = "90",Score = 3,OpponentScore = 2,LeagueId = 1,LeagueDateId = 1,PlannedTime = "9:30Pm",PlannedDate = DateTime.Parse("3/10/2012")},
      new Match() { Id = 2, MatchType = MatchTypes.History, Date = DateTime.Parse("2/6/2020"), SeasonId = 1,OpponentTeamId = 1,StadiumId = 1,RefereeId = 1,IsAway = false,Time = "90",Score = 3,OpponentScore = 2,LeagueId = 1,LeagueDateId = 1,PlannedTime = "9:30Pm",PlannedDate = DateTime.Parse("3/10/2022")},
      new Match() { Id = 3, MatchType = MatchTypes.History, Date = DateTime.Parse("2/6/2020"), SeasonId = 1,OpponentTeamId = 1,StadiumId = 1,RefereeId = 1,IsAway = false,Time = "90",Score = 3,OpponentScore = 2,LeagueId = 1,LeagueDateId = 1,PlannedTime = "9:30Pm",PlannedDate = DateTime.Parse("3/20/2022")},
      new Match() { Id = 4, MatchType = MatchTypes.Current, Date = DateTime.Parse("2/6/2020"), SeasonId = 1,OpponentTeamId = 1,StadiumId = 1,RefereeId = 1,IsAway = false,Time = "90",Score = 3,OpponentScore = 2,LeagueId = 1,LeagueDateId = 1,PlannedTime = "9:30Pm",PlannedDate = DateTime.Parse("8/23/2022")},
      new Match() { Id = 5, MatchType = MatchTypes.History, Date = DateTime.Parse("2/6/2020"), SeasonId = 1,OpponentTeamId = 3,StadiumId = 1,RefereeId = 1,IsAway = false,Time = "90",Score = 3,OpponentScore = 2,LeagueId = 1,LeagueDateId = 1, PlannedTime = "9:30Pm",PlannedDate = DateTime.Parse("3/12/2012")},
      new Match() { Id = 6, MatchType = MatchTypes.Upcoming, Date = DateTime.Parse("2/6/2022"), SeasonId = 1,OpponentTeamId = 2,StadiumId = 1,RefereeId = 1,IsAway = false,Time = "90",Score = null, OpponentScore = null, LeagueId = 1, LeagueDateId = 2, PlannedTime = "9:30Pm",PlannedDate = DateTime.Parse("3/10/2023")},
      new Match() { Id = 7, MatchType = MatchTypes.Upcoming, Date = DateTime.Parse("2/6/2022"), SeasonId = 1,OpponentTeamId = 1,StadiumId = 1,RefereeId = 1,IsAway = false,Time = "90",Score = null, OpponentScore = null, LeagueId = 1, LeagueDateId = 2, PlannedTime = "9:30Pm",PlannedDate = DateTime.Parse("5/10/2023")},
      new Match() { Id = 8, MatchType = MatchTypes.Upcoming, Date = DateTime.Parse("2/6/2022"), SeasonId = 1,OpponentTeamId = 3,StadiumId = 1,RefereeId = 1,IsAway = false,Time = "90",Score = null,OpponentScore = null,LeagueId = 1, LeagueDateId = 3, PlannedTime = "9:30Pm",PlannedDate = DateTime.Parse("3/10/2023")}
    );
    #endregion
  }
}
