#nullable disable
using System.ComponentModel.DataAnnotations.Schema;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;

public class MatchPlayer : BaseEntity<int>,IAggregateRoot
{
  [ForeignKey("Player")]public int PlayerId { get; set; }
  [ForeignKey("Match")]public int MatchId { get; set; }
  public Player Player { get; set; }
  public Match Match { get; set; }
  public DateTime Date { get; set; }
  public bool IsAvailable { get; set; }
}
