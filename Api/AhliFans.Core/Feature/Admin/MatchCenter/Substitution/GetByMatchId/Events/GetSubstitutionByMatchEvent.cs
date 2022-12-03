using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.Substitution.GetByMatchId.Events;

public record GetSubstitutionByMatchEvent(int MatchId,string Lang):IRequest<ActionResult>;
