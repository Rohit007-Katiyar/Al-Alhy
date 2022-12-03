#nullable disable
using System.ComponentModel.DataAnnotations.Schema;
using AhliFans.Core.Feature.Enums;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Interfaces;
using JetBrains.Annotations;

namespace AhliFans.Core.Feature.Entities;

public class Moment : BaseEntity<int>, IAggregateRoot
{
  [ForeignKey("Player")] public int PlayerId { get; set; }
  [ForeignKey("Match")] public int MatchId { get; set; }
  public Player Player { get; set; }
  public Match Match { get; set; }
  public DateTime? MomentTime { get; set; }
  [CanBeNull] public string MediaFileName { get; set; }
  public MomentVoteTypes Type { get; set; }
  public bool IsAvailable { get; set; }
  public DateTime From { get; set; }
  public DateTime To { get; set; }
}
