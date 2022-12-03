using AhliFans.Core.Feature.Security.Enums;
using AhliFans.SharedKernel.Enum;

namespace AhliFans.Core.Feature.Security.Login.Fan.DTO;
public record FanTokenDto(string Value, DateTime ExpirationDate, string Message, ResponseStatus Status);

