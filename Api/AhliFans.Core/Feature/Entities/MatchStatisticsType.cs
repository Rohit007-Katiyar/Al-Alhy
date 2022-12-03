using System.ComponentModel.DataAnnotations.Schema;
using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;

public partial class MatchStatisticsType : IAggregateRoot
{
  public MatchStatisticsType()
  {
    MatchStatistics = new HashSet<MatchStatistic>();
    MatchStatisticsTypeCoefficients = new HashSet<MatchStatisticsTypeCoefficient>();
  }

  public int Id { get; set; }
  public string Name { get; set; } = null!;
  public string NameAr { get; set; } = null!;
  public bool IsEnabled { get; set; }
  public virtual ICollection<MatchStatistic> MatchStatistics { get; set; }
  public virtual ICollection<MatchStatisticsTypeCoefficient> MatchStatisticsTypeCoefficients { get; set; }

  [ForeignKey(nameof(AdminCreate))] public Guid? CreatedBy { get; set; } = null!;

  [ForeignKey(nameof(AdminModify))] public Guid? ModifiedBy { get; set; } = null!;

  public DateTime CreatedOn { get; set; }

  public DateTime ModifiedOn { get; set; }

  public Security.Entities.Admin? AdminCreate { get; set; } = null!;

  public Security.Entities.Admin? AdminModify { get; set; } = null!;
}
