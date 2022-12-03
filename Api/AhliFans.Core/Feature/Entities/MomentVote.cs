#nullable disable
using System.ComponentModel.DataAnnotations.Schema;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;

public class MomentVote : BaseEntity<int>,IAggregateRoot
{
  [ForeignKey("Fan")] public Guid FanId { get; set; }
  [ForeignKey("Moment")] public int MomentId { get; set; }
  public Security.Entities.Fan Fan { get; set; }
  public Moment Moment { get; set; }
  public DateTime Date { get; set; }
}
