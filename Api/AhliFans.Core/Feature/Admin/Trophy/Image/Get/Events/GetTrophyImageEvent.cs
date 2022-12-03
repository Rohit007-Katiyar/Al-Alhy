using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Trophy.Image.Get.Events;
public record GetTrophyImageEvent(int TrophyId) :IRequest<ActionResult>;
