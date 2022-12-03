using System;
using System.Collections.Generic;

namespace AhliFans.Core.Feature.Entities;

public partial class MediaTag
{
  public int Id { get; set; }
  public int? LegendId { get; set; }
  public int? PlayerId { get; set; }
  public int? CoachId { get; set; }
  public int? MatchEventId { get; set; }
  public int? PhotoId { get; set; }
  public int? VideoId { get; set; }
  public DateTime Date { get; set; }

  public virtual Coach? Coach { get; set; }
  public virtual LegendBirthDate? Legend { get; set; }
  public virtual MatchEvent? MatchEvent { get; set; }
  public virtual Photo? Photo { get; set; }
  public virtual Player? Player { get; set; }
  public virtual Video? Video { get; set; }
}