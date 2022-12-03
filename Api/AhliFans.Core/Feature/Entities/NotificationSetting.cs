#nullable disable
using System.ComponentModel.DataAnnotations.Schema;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;

public class NotificationSetting : BaseEntity<int>,IAggregateRoot
{
  [ForeignKey("Fan")]public Guid FanId { get; set; }
  public Security.Entities.Fan Fan { get; set; }
  public bool? EnableAll { get; set; } = true;
  public bool? PlaySounds { get; set; } = true;
  public bool? News { get; set; }
  public bool? MatchStatus { get; set; }
  public bool? NightMode { get; set; }
  public string From { get; set; }
  public string To { get; set; }
}
