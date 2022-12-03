using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Team.GetAll.Events;

public record GetAllTeamsEvent(int PageIndex, int PageSize, string? TeamName, bool IsDeleted, string Lang) :IRequest<ActionResult>;
