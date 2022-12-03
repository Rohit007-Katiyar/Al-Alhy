using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Preferences.Get.Events;

public record GetPreferenceEvent(Guid FanId,string Lang):IRequest<ActionResult>;
