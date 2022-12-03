using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Stadium.ChangeStatus.Events;
public record ChangeStadiumStatusEvent(int StadiumId) :IRequest<ActionResult>;
