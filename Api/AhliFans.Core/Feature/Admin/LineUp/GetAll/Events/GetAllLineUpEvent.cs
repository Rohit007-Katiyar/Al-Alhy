using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.LineUp.GetAll.Events;

public record GetAllLineUpEvent(string Lang,int PageIndex, int PageSize, DateTime? Date, string? OpponentTeam):IRequest<ActionResult>;
