using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.GetById.Events;

public record GetPlayerByIdEvent(int PlayerId,string Language) : IRequest<ActionResult>;
