using System;
using System.Collections.Generic;

namespace AhliFans.Core.Feature.Entities;

public partial class PlayerTeam
{
  public int Id { get; set; }
  public int PlayerId { get; set; }
  public int TeamTypeId { get; set; }
  public DateTime SignedDate { get; set; }

  public virtual Player Player { get; set; } = null!;
}