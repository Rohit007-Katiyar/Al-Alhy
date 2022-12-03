using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;

public partial class MatchStatisticsTypeCoefficient : IAggregateRoot
{
  public MatchStatisticsTypeCoefficient()
  {
    MatchStatistics = new HashSet<MatchStatistic>();
  }

  public int Id { get; set; }
  public int MatchStatisticsTypeId { get; set; }
  public string Name { get; set; } = null!;
  public string NameAr { get; set; } = null!;
  public bool IsPercentage { get; set; }
  public virtual MatchStatisticsType MatchStatisticsType { get; set; } = null!;
  public virtual ICollection<MatchStatistic> MatchStatistics { get; set; }

  [ForeignKey(nameof(AdminCreate))] public Guid? CreatedBy { get; set; } = null!;

  [ForeignKey(nameof(AdminModify))] public Guid? ModifiedBy { get; set; } = null!;

  public DateTime CreatedOn { get; set; }

  public DateTime ModifiedOn { get; set; }

  public Security.Entities.Admin? AdminCreate { get; set; } = null!;

  public Security.Entities.Admin? AdminModify { get; set; } = null!;
}
