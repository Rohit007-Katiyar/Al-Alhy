using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Stadium.GetAll.Events;

public record GetAllStadiumsEvent(string Lang, int PageIndex, int PageSize,bool IsDeleted):IRequest<ActionResult>;
