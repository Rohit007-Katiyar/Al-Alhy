using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.GetByPosition.Events;

public record GetPlayerByPositionEvent(int? TeamId, int GeneralPosition,string Lang, int? TeamCategoryId) : IRequest<ActionResult>;
