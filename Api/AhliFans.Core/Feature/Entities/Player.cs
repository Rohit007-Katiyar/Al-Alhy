using System.ComponentModel.DataAnnotations.Schema;
using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;

public partial class Player : IAggregateRoot
{
  public Player()
  {
    FanPreferences = new HashSet<FanPreference>();
    Honors = new HashSet<Honor>();
    MatchLineUps = new HashSet<MatchLineUp>();
    MediaTags = new HashSet<MediaTag>();
    PlayerTeams = new HashSet<PlayerTeam>();
    SocialMediaAccounts = new HashSet<SocialMediaAccount>();
    SquadLists = new HashSet<SquadList>();
  }

  public int Id { get; set; }
  public int? PositionId { get; set; }
  public int? Number { get; set; }
  public string? Name { get; set; }
  public string? NameAr { get; set; }
  public DateTime? BirthDate { get; set; }
  public DateTime? DateSigned { get; set; }
  public int? Height { get; set; }
  public int? Weight { get; set; }
  public string? Biography { get; set; }
  public string? BiographyAr { get; set; }
  public string? Pic { get; set; }
  public DateTime Date { get; set; }
  public bool IsDeleted { get; set; }
  [ForeignKey("City")] public int? CityOfBirthId { get; set; }
  [ForeignKey("Country")] public int? CountryHeLiveIn { get; set; }
  [ForeignKey("Team")] public int? TeamId { get; set; }

  [ForeignKey(nameof(TeamCategory))] public int? TeamCategoryId { get; set; }

  public virtual Position? Position { get; set; }
  public virtual City? CityOfBirth { get; set; }
  public virtual Country? Country { get; set; }

  public virtual TeamType? TeamCategory { get; set; }
  public virtual Team? Team { get; set; }
  public virtual ICollection<FanPreference> FanPreferences { get; set; }
  public virtual ICollection<Honor> Honors { get; set; }
  public virtual ICollection<MatchLineUp> MatchLineUps { get; set; }
  public virtual ICollection<MediaTag> MediaTags { get; set; }
  public virtual ICollection<PlayerTeam> PlayerTeams { get; set; }
  public virtual ICollection<SocialMediaAccount> SocialMediaAccounts { get; set; }
  public virtual ICollection<SquadList> SquadLists { get; set; }
}
