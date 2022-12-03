using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Notification.Setting.Edit.Events;

public record EditNotificationSettingsEvent(bool? EnableAll, bool? PlaySounds, bool? News, bool? MatchStatus, bool? NightMode, string? From, string? To) : IRequest<ActionResult>;
