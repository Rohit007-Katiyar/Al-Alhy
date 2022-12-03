using AhliFans.SharedKernel.Enum;

namespace AhliFans.SharedKernel;
public record EndPointResponse(string Title, string Message, ResponseStatus Status);
public record FanResponse(string Message, ResponseStatus Status) : EndPointResponse("Ahli Fan", Message, Status);
public record AdminResponse(string Message, ResponseStatus Status) : EndPointResponse("Ahli Admin", Message, Status);
