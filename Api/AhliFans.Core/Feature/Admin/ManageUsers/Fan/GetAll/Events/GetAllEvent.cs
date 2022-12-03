using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.ManageUsers.Fan.GetAll.Events;

public record GetAllEvent(int PageIndex, int PageSize, string SearchWord, bool IsBlocked) : IRequest<ActionResult>;
