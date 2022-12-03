using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.SocialMediaAccounts.ChangeStatus.Events;

public record ChangeAccountStatusEvent(int AccountId) : IRequest<ActionResult>;
