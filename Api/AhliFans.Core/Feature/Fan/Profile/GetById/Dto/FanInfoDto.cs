using AhliFans.Core.Feature.Enums;

namespace AhliFans.Core.Feature.Fan.Profile.GetById.DTO;
public record FanInfoDto(string FullName, string Email, string PhoneNumber, string Gender,
  string? BirthDate, CityObj City, CountryObj Nationality, SocialMediaLink LinkedWith);

public record CityObj(int Id, string Name);
public record CountryObj(int CountryId, string Country);
