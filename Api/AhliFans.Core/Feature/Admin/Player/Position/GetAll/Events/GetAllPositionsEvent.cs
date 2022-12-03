using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.Position.GetAll.Events;

public record GetAllPositionsEvent(string Lang,string Name,bool IsDeleted):IRequest<ActionResult>;
