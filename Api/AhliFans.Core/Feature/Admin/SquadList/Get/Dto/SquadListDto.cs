namespace AhliFans.Core.Feature.Admin.SquadList.Get.Dto;

public class SquadListPlayerDto
{
  public int SquadListId { get; set; }
  public int PlayerId { get; set; }

  public string PlayerName { get; set; } = string.Empty;
}

