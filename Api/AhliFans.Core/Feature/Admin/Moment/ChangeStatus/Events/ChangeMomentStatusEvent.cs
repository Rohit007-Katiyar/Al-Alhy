using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Moment;

public record ChangeMomentStatusEvent(int MomentId) :IRequest<ActionResult>;
