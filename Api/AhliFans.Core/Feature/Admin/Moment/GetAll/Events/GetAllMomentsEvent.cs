using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Moment.GetAll.Events;

public record GetAllMomentsEvent(string Lang, int PageIndex, int PageSize, bool IsAvailable) :IRequest<ActionResult>;
