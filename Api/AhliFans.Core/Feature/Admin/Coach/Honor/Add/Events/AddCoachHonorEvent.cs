using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.Honor.Add.Events;

public record AddCoachHonorEvent(int CoachId, int TrophyId,  bool IsPersonal):IRequest<ActionResult>;
