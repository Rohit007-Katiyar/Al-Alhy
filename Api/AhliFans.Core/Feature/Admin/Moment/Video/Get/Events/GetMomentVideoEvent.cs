using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Moment;
public record GetMomentVideoEvent(int MomentId) :IRequest<ActionResult>;
