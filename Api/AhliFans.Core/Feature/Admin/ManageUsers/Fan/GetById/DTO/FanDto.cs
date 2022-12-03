using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.Core.Feature.Admin.ManageUsers.Fan.GetById.DTO;

public record FanDto(string FUllName, string? Email,string PhoneNumber,DateTime? BirthDate,Gender? Gender,string Country, string City);
