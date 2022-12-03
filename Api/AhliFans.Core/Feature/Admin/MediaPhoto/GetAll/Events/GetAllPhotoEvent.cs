using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MediaPhoto.GetAll.Events;
public record GetAllPhotoEvent(string? SearchWord, string Lang, int PageIndex, int PageSize, bool IsDeleted) : IRequest<ActionResult>;
