using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.GetById.Events;

public record GetCoachByIdEvent(int CoachId,string Lang):IRequest<ActionResult>;
