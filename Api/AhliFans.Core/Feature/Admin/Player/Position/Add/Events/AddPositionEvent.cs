using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.Position.Add.Events;

public record AddPositionEvent(string Name, string NameAr, string? Symbol, int GeneralPositionId) :IRequest<ActionResult>;
