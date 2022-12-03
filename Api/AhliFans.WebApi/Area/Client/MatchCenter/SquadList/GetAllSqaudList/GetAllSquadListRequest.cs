using AhliFans.Core.Feature.Security.Enums;
namespace AhliFans.WebApi.Area.Client.MatchCenter.SquadList.GetAllSqaudList;

public record GetAllSquadListRequest(string? Lang)
{
    public const string Route = $"{nameof(Areas.Client)}/AllSquadList";
}

