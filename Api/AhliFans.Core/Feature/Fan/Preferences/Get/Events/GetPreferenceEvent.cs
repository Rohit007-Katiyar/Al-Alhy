using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Preferences.Get.Events;

public record GetPreferenceEvent(string Lang):IRequest<ActionResult>;
