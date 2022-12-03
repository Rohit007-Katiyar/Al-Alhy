using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhliFans.SharedKernel.Interfaces;

namespace AhliFans.Core.Feature.Entities;
public partial class MomentVideo : IAggregateRoot
{
  public MomentVideo()
  {

  }
  public int Id { get; set; }

  public int SeasonId { get; set; }
  public int? MatchId { get; set; }
  public int LeagueId { get; set; }
  public int PlayerId { get; set; }
  public int Time { get; set; }
  public string VideoType { get; set; }
  public int? CategoryId { get; set; }
  public string Month { get; set; } = null!;
  public string VideoURL { get; set; } = null!;
  public string Description { get; set; } = null!;
  public string DescriptionAr { get; set; } = null!;
  public DateTime CreatedOn { get; set; } = DateTime.Now;
  public DateTime? ModifiedOn { get; set; }
  public bool IsDeleted { get; set; }
  public Security.Entities.Admin? CreatedBy { get; set; }
  [ForeignKey(nameof(CreatedBy))]
  public Guid CreatedById { get; set; }

  public Security.Entities.Admin? ModifiedBy { get; set; }
  [ForeignKey(nameof(ModifiedBy))]
  public Guid? ModifiedById { get; set; }

  public virtual Season Season { get; set; } = null!;
  public virtual Match Match { get; set; } = null!;
  public virtual League League { get; set; } = null!;
  public virtual Category Category { get; set; } = null!;
  public virtual Player Player { get; set; } = null!;
}
