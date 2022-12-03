using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Player.GetInfo.Events;

public record GetPlayerByIdEvent(int PlayerId,string Language) : IRequest<ActionResult>;
