using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Profile.GetById.Events;
public record GetByIdEvent:IRequest<ActionResult>;
