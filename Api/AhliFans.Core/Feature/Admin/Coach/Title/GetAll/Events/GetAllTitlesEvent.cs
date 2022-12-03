using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.Title.GetAll.Events;
public record GetAllTitlesEvent(string SearchWord, string Lang, int PageIndex, int PageSize, bool RequestIsDeleted) : IRequest<ActionResult>;
