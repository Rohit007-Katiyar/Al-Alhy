using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.GetAll.Events;

public record GetAllPlayersEvent(int PageIndex, int PageSize, string PlayerName, string Lang, bool IsDeleted) : IRequest<ActionResult>;
