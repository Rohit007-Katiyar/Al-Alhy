using AhliFans.SharedKernel.Enum;

namespace AhliFans.Core.Feature.Security.Login.Admin.DTO;
public record TokenDto(string Value, DateTime ExpirationDate, string Message, ResponseStatus Status);


