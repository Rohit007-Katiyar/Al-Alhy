using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.FBLogin.Fan.Events;

public record FbLoginEvent(string AccessToken):IRequest<ActionResult>;
