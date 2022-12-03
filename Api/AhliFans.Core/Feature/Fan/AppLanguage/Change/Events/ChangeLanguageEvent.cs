using AhliFans.Core.Feature.Security.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.AppLanguage.Change.Events;
public record ChangeLanguageEvent(Language Language):IRequest<ActionResult>;
