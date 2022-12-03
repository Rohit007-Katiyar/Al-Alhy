using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.Title.GetById.Events;

public record GetTitleByIdEvent(int TitleId):IRequest<ActionResult>;
