using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Referee.GetAll.Events;

public record GetAllRefereesEvent(string? SearchWord, string Lang, int PageIndex, int PageSize, bool IsDeleted) : IRequest<ActionResult>;
