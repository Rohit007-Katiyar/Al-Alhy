using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Security.LinkSocialMedia.Fan.FaceBook;

public record LinkFaceBookAccountEvent(string Token):IRequest<ActionResult>;
