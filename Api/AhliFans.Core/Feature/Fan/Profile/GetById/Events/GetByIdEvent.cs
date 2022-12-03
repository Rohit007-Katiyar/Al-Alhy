using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Profile.GetById.Events;

public record GetByIdEvent(string Lang) : IRequest<ActionResult>;
