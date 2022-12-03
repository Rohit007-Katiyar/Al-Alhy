using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Player.GetByPosition.Events;

public record GetPlayerByPositionEvent(int? TeamId, int GeneralPosition,string Lang) : IRequest<ActionResult>;
