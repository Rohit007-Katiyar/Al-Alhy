#nullable disable
using System.ComponentModel.DataAnnotations.Schema;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;
public class PlayerVote : BaseEntity<int>,IAggregateRoot
{
  [ForeignKey("Player")] public int PlayerId { get; set; }
  [ForeignKey("Match")] public int MatchId { get; set; }
  [ForeignKey("Fan")]public Guid FanId { get; set; }
  public Player Player { get; set; }
  public Match Match { get; set; }
  public Security.Entities.Fan Fan { get; set; }
  public DateTime Time { get; set; }
}
