namespace AhliFans.Core.Feature.Admin.Player.GetById.DTO;
public record PlayerInfoDto(int Id,string Position,string? PositionName, int? Number, string? Name, string? NameAr, DateTime? BirthDate,
  int? Height, int? Weight, string? Biography, string? BiographyAr, string? Nationality, string? CityOfBirth, bool IsDeleted,DateTime? SignedDate, string? CountryHeLive, int? TeamCategoryId, string? TeamCategoryName);
