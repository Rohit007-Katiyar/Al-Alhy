using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.LinkSocialMedia.Fan.Gmail;

public record LinkGmailEvent(string Email):IRequest<ActionResult>;
