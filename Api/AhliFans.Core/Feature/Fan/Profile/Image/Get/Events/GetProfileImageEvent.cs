using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Profile.Image.Get.Events;

public record GetProfileImageEvent : IRequest<ActionResult>;
