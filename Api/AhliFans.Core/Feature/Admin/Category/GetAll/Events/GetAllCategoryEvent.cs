using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Category.GetAll.Events;
public record GetAllCategoryEvent(int PageIndex, int PageSize, string? SearchWord, bool IsDeleted , string type, string Lang) : IRequest<ActionResult>;
