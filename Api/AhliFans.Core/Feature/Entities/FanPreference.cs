using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;

public partial class FanPreference : IAggregateRoot
{
  public int Id { get; set; }
  [ForeignKey("Fan")]public Guid? FanId { get; set; }
  [ForeignKey("Player")] public int? PlayerId { get; set; }
  [ForeignKey("LocalTrophy")] public int? LocalTrophyId { get; set; }
  [ForeignKey("AfricanTrophy")] public int? AfricanTrophyId { get; set; }
  [ForeignKey("Match")] public int? MatchId { get; set; }
  public string? FavoritePlayerAllTime { get; set; }
  public string? FavoriteCoachAllTime { get; set; }
  public string? FavoriteMoment { get; set; }
  public DateTime? Date { get; set; }

  public virtual Security.Entities.Fan? Fan { get; set; }
  public virtual Player? Player { get; set; }
  public virtual Coach? Coach { get; set; }
  public virtual Trophy? LocalTrophy { get; set; }
  public virtual Trophy? AfricanTrophy { get; set; }
  public virtual Match? Match { get; set; }
}
