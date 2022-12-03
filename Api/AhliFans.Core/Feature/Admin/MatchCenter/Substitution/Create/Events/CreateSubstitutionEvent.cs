using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.Substitution.Create;

public record CreateSubstitutionEvent(int PlayerId, int SubstitutionPlayer, int MatchId) :IRequest<ActionResult>;
