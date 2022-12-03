using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.Title.Edit.Events;

public record EditTitleEvent(int TitleId, string? Text, string? TextAr) :IRequest<ActionResult>;
