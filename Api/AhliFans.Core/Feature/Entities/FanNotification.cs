#nullable disable
using System.ComponentModel.DataAnnotations.Schema;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;

public class FanNotification : BaseEntity<int>,IAggregateRoot
{
  [ForeignKey("Fan")]public Guid FanId { get; set; }
  public virtual Security.Entities.Fan Fan { get; set; }
  [ForeignKey("Notification")] public int NotificationId { get; set; }
  public virtual Notification Notification { get; set; }
  public bool Read { get; set; }
  public DateTime Data { get; set; }
}
