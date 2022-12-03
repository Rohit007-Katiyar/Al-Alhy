using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Moment.GetById.Events;

public record GetMomentByIdEvent(int MomentId,string Lang):IRequest<ActionResult>;
