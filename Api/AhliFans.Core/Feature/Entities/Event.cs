using System;
using System.Collections.Generic;

namespace AhliFans.Core.Feature.Entities;

public partial class Event
{
  public int Id { get; set; }
  public string Name { get; set; } = null!;
  public string NameAr { get; set; } = null!;
  public DateTime DateFrom { get; set; }
  public DateTime DateTo { get; set; }
  public TimeSpan? TimeFrom { get; set; }
  public TimeSpan? TimeTo { get; set; }
  public string? Description { get; set; }
  public string? DescriptionAr { get; set; }
  public DateTime Date { get; set; }
}
