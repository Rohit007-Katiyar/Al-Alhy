using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Coach.GetImage;
public record GetCoachImageEvent(int CoachId) :IRequest<ActionResult>;
