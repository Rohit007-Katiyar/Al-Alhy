using AhliFans.Core.Feature.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Moment.Edit.Events;

public record EditMomentEvent(int MomentId,int? PlayerId, int? MatchId, DateTime? MomentTime, MomentVoteTypes? Type, DateTime? VotingStartFrom, DateTime? To) : IRequest<ActionResult>;
