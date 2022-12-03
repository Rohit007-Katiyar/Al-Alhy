namespace AhliFans.Core.Feature.Fan.Category.GetAll.DTO;

public record DataDto(string leagueName, string matchName, string? logo, string url, 
  bool? isVideo, bool? isExclusiveContent, string month, string thumbnailUrl, string type, DateTime? createdDate);

