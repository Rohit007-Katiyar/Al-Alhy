using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.AppLanguage.Get.Events;
public record GetLanguageEvent:IRequest<ActionResult>;
