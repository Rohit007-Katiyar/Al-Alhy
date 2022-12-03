using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Notification.Setting.Add.Events;

public record AddSettingEvent(Guid FanId,bool? EnableAll, bool? PlaySounds, bool? News, bool? MatchStatus, bool? NightMode, string? From, string? To) :IRequest<ActionResult>;
