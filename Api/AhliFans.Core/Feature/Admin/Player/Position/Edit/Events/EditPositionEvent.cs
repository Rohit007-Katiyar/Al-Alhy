using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.Position.Edit.Events;

public record EditPositionEvent(int PositionId, int? GeneralPositionId, string? Name, string? NameAr, string? Symbol) :IRequest<ActionResult>;
