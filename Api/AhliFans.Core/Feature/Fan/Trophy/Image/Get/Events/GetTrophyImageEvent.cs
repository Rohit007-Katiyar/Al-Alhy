using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Trophy.Image.Get.Events;
public record GetTrophyImageEvent(int TrophyId) :IRequest<ActionResult>;
