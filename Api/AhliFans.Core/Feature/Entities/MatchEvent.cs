
namespace AhliFans.Core.Feature.Entities;

public partial class MatchEvent
{
  public MatchEvent()
  {
    MediaTags = new HashSet<MediaTag>();
  }

  public int Id { get; set; }
  public int MatchEventTypeId { get; set; }
  public int MatchId { get; set; }
  public int Minute { get; set; }
  public bool IsSecondHalf { get; set; }
  public DateTime Date { get; set; }

  public virtual Match Match { get; set; } = null!;
  public virtual MatchEventType MatchEventType { get; set; } = null!;
  public virtual ICollection<MediaTag> MediaTags { get; set; }
}
