#nullable disable
using System.ComponentModel.DataAnnotations.Schema;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Interfaces;
using JetBrains.Annotations;

namespace AhliFans.Core.Feature.Entities;

public class Notification : BaseEntity<int>, IAggregateRoot
{
  [ForeignKey("Admin")]public Guid AdminId { get; set; }
  public Security.Entities.Admin Admin { get; set; } = null!;
  public string Header { get; set; }
  public string Body { get; set; }
  public string Icon { get; set; }
  [CanBeNull] public string Link { get; set; }
  public DateTime SendTime { get; set; }
  public ICollection<FanNotification> FanNotifications { get; set; }
}
