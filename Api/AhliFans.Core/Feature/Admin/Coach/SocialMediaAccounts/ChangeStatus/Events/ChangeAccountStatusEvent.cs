using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.SocialMediaAccounts.ChangeStatus.Events;

public record ChangeAccountStatusEvent(int AccountId) : IRequest<ActionResult>;
