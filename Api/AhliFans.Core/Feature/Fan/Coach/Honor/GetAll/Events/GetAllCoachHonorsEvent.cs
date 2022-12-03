using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Coach.Honor.GetAll.Events;

public record GetAllCoachHonorsEvent(int CoachId, int TrophyTypeId, string Lang,int PageIndex,int PageSize,bool IsDeleted) : IRequest<ActionResult>;
