using System;
using System.Collections.Generic;
using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;

public partial class MatchLineUp : IAggregateRoot
{
  public int Id { get; set; }
  public int MatchId { get; set; }
  public int PlayerId { get; set; }
  public int? PositionId { get; set; }
  public bool IsSubstitute { get; set; }
  public decimal? X { get; set; }
  public decimal? Y { get; set; }
  public DateTime Date { get; set; }

  public virtual Match Match { get; set; } = null!;
  public virtual Player Player { get; set; } = null!;
  public virtual Position? Position { get; set; } = null!;
}
