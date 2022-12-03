using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.Honor.GetAll.Events;

public record GetAllCoachHonorsEvent(int? CoachId,string Lang,int PageIndex,int PageSize,bool IsDeleted) : IRequest<ActionResult>;
