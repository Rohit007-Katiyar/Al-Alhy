using AhliFans.Core.Feature.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Moment.Add.Events;

public record AddMomentEvent(int PlayerId, int MatchId, DateTime? MomentTime, MomentVoteTypes Type, IFormFile? MomentVideo,
  DateTime VotingStartFrom, DateTime To):IRequest<ActionResult>;
