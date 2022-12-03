#nullable disable
using System.ComponentModel.DataAnnotations.Schema;
using AhliFans.SharedKernel.Interfaces;
using JetBrains.Annotations;

namespace AhliFans.Core.Feature.Entities;

public partial class Coach : IAggregateRoot
{
  public Coach()
  {
    Honors = new HashSet<Honor>();
    MediaTags = new HashSet<MediaTag>();
    SocialMediaAccounts = new HashSet<SocialMediaAccount>();
  }

  public int Id { get; set; }
  [ForeignKey("City")] public int CityId { get; set; }
  [ForeignKey("Country")] public int? CountryId { get; set; }

  [ForeignKey(nameof(TeamCategory))] public int? TeamCategoryId { get; set; }
  public int TitleId { get; set; }
  public string FirstName { get; set; } = null!;
  public string FirstNameAr { get; set; } = null!;
  public string LastName { get; set; } = null!;
  public string LastNameAr { get; set; } = null!;
  public DateTime BirthDate { get; set; }
  public DateTime DateSigned { get; set; }
  public string Biography { get; set; } = null!;
  public string BiographyAr { get; set; } = null!;
  [CanBeNull] public string Pic { get; set; }
  public bool IsCurrent { get; set; }
  public DateTime Date { get; set; }
  public bool IsDeleted { get; set; }

  public virtual Title Title { get; set; } = null!;
  public virtual TeamType TeamCategory { get; set; } = null!;
  public virtual City City { get; set; }
  [CanBeNull] public virtual Country Country { get; set; }
  public virtual ICollection<Honor> Honors { get; set; }
  public virtual ICollection<MediaTag> MediaTags { get; set; }
  public virtual ICollection<SocialMediaAccount> SocialMediaAccounts { get; set; }
}
