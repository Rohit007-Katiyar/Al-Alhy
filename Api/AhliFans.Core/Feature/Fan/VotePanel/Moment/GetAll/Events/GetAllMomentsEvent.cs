using AhliFans.Core.Feature.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.VotePanel.Moment.GetAll.Events;

public record GetAllMomentsEvent(int PageIndex, int PageSize, MomentVoteTypes MomentType,string Lang) : IRequest<ActionResult>;

