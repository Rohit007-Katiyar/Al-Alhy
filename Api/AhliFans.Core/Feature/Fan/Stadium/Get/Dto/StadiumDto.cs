namespace AhliFans.Core.Feature.Fan.Stadium.Get.Dto;

public class StadiumDto
{
  public int Id { get; set; }

  public int RegionId { get; set; }

  public string Name { get; set; } = string.Empty;

  public string Latitude { get; set; } = string.Empty;

  public string Longitude { get; set; } = string.Empty;

  public string RegionName { get; set; } = string.Empty;
}
