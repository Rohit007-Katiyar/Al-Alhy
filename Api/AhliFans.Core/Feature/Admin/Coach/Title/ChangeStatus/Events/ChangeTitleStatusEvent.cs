using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.Title.ChangeStatus.Events;
public record ChangeTitleStatusEvent(int TitleId) :IRequest<ActionResult>;
