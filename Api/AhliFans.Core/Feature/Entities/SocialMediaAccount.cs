#nullable disable
using AhliFans.Core.Feature.Enums;
using AhliFans.SharedKernel.Interfaces;
using JetBrains.Annotations;

namespace AhliFans.Core.Feature.Entities;

public class SocialMediaAccount : IAggregateRoot
{
  public int Id { get; set; }
  public int? CoachId { get; set; }
  public int? PlayerId { get; set; }
  public string SocialMediaAccount1 { get; set; }
  public bool IsDeleted { get; set; }
  public DateTime Date { get; set; }
  public SocialMediaTypes? Type { get; set; }

  [CanBeNull] public virtual Coach Coach { get; set; } 
  [CanBeNull] public virtual Player Player { get; set; } 
}
