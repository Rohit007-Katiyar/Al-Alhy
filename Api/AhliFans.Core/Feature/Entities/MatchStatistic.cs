using System.ComponentModel.DataAnnotations.Schema;
using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;

public partial class MatchStatistic : IAggregateRoot
{
  public int Id { get; set; }
  public int MatchId { get; set; }
  public int StatisticsTypeId { get; set; }
  public int StatisticsCoefficientId { get; set; }
  public int Value { get; set; }
  public virtual Match Match { get; set; } = null!;
  public virtual MatchStatisticsTypeCoefficient StatisticsCoefficient { get; set; } = null!;
  public virtual MatchStatisticsType StatisticsType { get; set; } = null!;

  [ForeignKey(nameof(AdminCreate))] public Guid? CreatedBy { get; set; } = null!;

  [ForeignKey(nameof(AdminModify))] public Guid? ModifiedBy { get; set; } = null!;

  public DateTime CreatedOn { get; set; }

  public DateTime ModifiedOn { get; set; }

  public Security.Entities.Admin? AdminCreate { get; set; } = null!;

  public Security.Entities.Admin? AdminModify { get; set; } = null!;
}
