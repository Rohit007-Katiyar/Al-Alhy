#nullable disable
using System.ComponentModel.DataAnnotations.Schema;
using AhliFans.Core.Feature.Enums;
using AhliFans.SharedKernel.Interfaces;
using JetBrains.Annotations;
using MatchTypes = AhliFans.Core.Feature.Enums.MatchTypes;

namespace AhliFans.Core.Feature.Entities;

public partial class Match : IAggregateRoot
{
  public Match()
  {
    MatchEvents = new HashSet<MatchEvent>();
    MatchLineUps = new HashSet<MatchLineUp>();
    MatchTags = new HashSet<MatchTag>();
    SquadLists = new HashSet<SquadList>();
    Statistics = new HashSet<MatchStatistic>();
  }
  public int Id { get; set; }
  public int SeasonId { get; set; }
  public int OpponentTeamId { get; set; }
  public int StadiumId { get; set; }
  public int RefereeId { get; set; }
  [ForeignKey("League")] public int LeagueId { get; set; }
  [ForeignKey("LeagueDate")] public int? LeagueDateId { get; set; }
  [ForeignKey("Jersey")] public int? JerseyId { get; set; }
  [ForeignKey("BroadcastChannel")] public int? BroadcastChannelId { get; set; }
  public bool IsAway { get; set; }
  public string Time { get; set; }
  public int? Score { get; set; }
  public int? OpponentScore { get; set; }
  public bool IsDeleted { get; set; }
  public bool IsAvailable { get; set; }
  public MatchTypes MatchType { get; set; }
  public MatchStatus? MatchStatus { get; set; }
  public DateTime? ActualDate { get; set; }
  [CanBeNull] public string ActualTime { get; set; }
  public DateTime PlannedDate { get; set; }
  public string PlannedTime { get; set; }
  public DateTime Date { get; set; }
  public virtual Team OpponentTeam { get; set; } = null!;
  public virtual Referee Referee { get; set; } = null!;
  public virtual Season Season { get; set; } = null!;
  public virtual Stadium Stadium { get; set; } = null!;
  public virtual League League { get; set; } = null!;
  public virtual Jersey Jersey { get; set; } = null!;
  [CanBeNull] public virtual LeagueDates LeagueDate { get; set; } = null!;
  [CanBeNull] public virtual BroadcastChannel BroadcastChannel { get; set; }
  public virtual ICollection<MatchEvent> MatchEvents { get; set; }
  public virtual ICollection<MatchLineUp> MatchLineUps { get; set; }
  public virtual ICollection<MatchTag> MatchTags { get; set; }
  public virtual ICollection<SquadList> SquadLists { get; set; }
  public virtual ICollection<MatchMedia> Media { get; set; }
  public virtual ICollection<MatchStatistic> Statistics { get; set; }
}
