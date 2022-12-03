namespace AhliFans.Core.Feature.Fan.Player.GetInfo.DTO;
public record PlayerInfoDto(int Id,string Position, int? Number, string? Name, string BirthDate,int Age,
  int? Height, int? Weight, string? Biography,string Nationality,string CityOfBirth, bool IsDeleted,string SignedDate,
  string CountryHeLive);
