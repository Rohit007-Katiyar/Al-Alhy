using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Coach.GetInfo.Events;

public record GetCoachByIdEvent(int CoachId,string Lang):IRequest<ActionResult>;
