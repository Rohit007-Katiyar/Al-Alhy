using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.Core.Feature.Admin.ManageUsers.Fan.GetAll.Dto;
public record FanInfoDto(Guid Id,string FullName, string Email, string PhoneNumber, Gender? Gender, string? BirthDate, bool IsBlocked);
