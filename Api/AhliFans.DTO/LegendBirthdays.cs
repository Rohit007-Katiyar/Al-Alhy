using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.DTO;
public class LegendBirthdays : IRequest<ActionResult>
{
  public long? Id { get; set; }
  public string Media { get; set; }
  public string LegendName { get; set; }
  public string LegendNameAr { get; set; }
  public DateTime? Date { get; set; }
  public string Description { get; set; }
  public string DescriptionAr { get; set; }
  public bool Regular { get; set; }
  public bool Legend { get; set; }
  public bool IsDeleted { get; set; }
}

public class ImportantMatch : IRequest<ActionResult>
{
  public long? Id { get; set; }
  public string AlAhly { get; set; }
  public string AlAhlyId { get; set; }
  public string OtherTeam { get; set; }
  public string OtherTeamId { get; set; }
  public string AlAhlyScore { get; set; }
  public string OtherTeamScore { get; set; }
  public string DateofMatch { get; set; }
  public string Description { get; set; }
  public string DescriptionAr { get; set; }
  public string Media { get; set; }
  public bool IsDeleted { get; set; }
}

public class BigTrophies : IRequest<ActionResult>
{
  public long? Id { get; set; }
  public string Media { get; set; }
  public string TrophyTypeId { get; set; }
  public string TrophyType { get; set; }
  public string TrophyNameId { get; set; }
  public string TrophyName { get; set; }
  public DateTime? DateofTrophy { get; set; }
  public string Description { get; set; }
  public string DescriptionAr { get; set; }
  public bool IsDeleted { get; set; }
}

public class RegularBirthDay : IRequest<ActionResult>
{
  public long Id { get; set; }
  public bool Regular { get; set; }
  public bool Legend { get; set; }
  public string Media { get; set; }
  public string PlayerName { get; set; }
  public string PlayerNameAr { get; set; }
  public int Age { get; set; }
  public bool IsDeleted { get; set; }
  public DateTime BirthDate { get; set; }
}

public class Events : IRequest<ActionResult>
{
  public long Id { get; set; }
  public string Media { get; set; }
  public string EventName { get; set; }
  public string EventNameAr { get; set; }
  public DateTime DateFrom { get; set; }
  public DateTime DateTo { get; set; }
  public TimeSpan EventTimeFrom { get; set; }
  public TimeSpan EventTimeTo { get; set; }
  public string Description { get; set; }
  public string DescriptionAr { get; set; }
  public string Location { get; set; }
  public bool IsDeleted { get; set; }
}
