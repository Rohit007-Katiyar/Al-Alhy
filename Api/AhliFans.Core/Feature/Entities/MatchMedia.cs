#nullable disable
using System.ComponentModel.DataAnnotations.Schema;
using AhliFans.Core.Feature.Enums;
using AhliFans.SharedKernel;
using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;
public class MatchMedia : BaseEntity<int>,IAggregateRoot
{
  public string FileName { get; set; }
  public MediaType MediaType { get; set; }
  [ForeignKey("Match")] public int MatchId { get; set; }
  public Match Match { get; set; }
  public bool IsDeleted { get; set; }
}
