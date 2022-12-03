using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.Honor.Edit.Events;

public record EditCoachHonorEvent(int HonorId, int? CoachId, int? TrophyId, bool? IsPersonal):IRequest<ActionResult>;
