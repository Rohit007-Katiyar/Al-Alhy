using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.Image.Get.Events;
public record GetCoachImageEvent(int CoachId) :IRequest<ActionResult>;
