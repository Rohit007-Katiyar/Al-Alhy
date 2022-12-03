#nullable disable
using System.ComponentModel.DataAnnotations.Schema;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;

public class Substitution : BaseEntity<int>,IAggregateRoot
{
  [ForeignKey("Player")]public int PlayerId { get; set; }
  [ForeignKey("SubstitutionPlayer")]public int SubstitutionPlayerId { get; set; }
  [ForeignKey("Match")]public int MatchId { get; set; }
  public Player Player { get; set; }
  public Match Match { get; set; }
  public Player SubstitutionPlayer { get; set; }
  public DateTime Date { get; set; }
}
