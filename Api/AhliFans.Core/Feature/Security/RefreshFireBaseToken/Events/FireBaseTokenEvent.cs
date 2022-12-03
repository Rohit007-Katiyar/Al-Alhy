using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.RefreshFireBaseToken.Events;

public record FireBaseTokenEvent(string Token):IRequest<ActionResult>;
