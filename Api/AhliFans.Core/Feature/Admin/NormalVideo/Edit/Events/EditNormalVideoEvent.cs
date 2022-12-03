using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.NormalVideo.Edit.Events;
public record EditNormalVideoEvent(int NormalVideoId, int SeasonId, string Month, string VideoURL,
  int MatchId, int LeagueId, string Description, string DescriptionAr, int? PlayerId, int? CoachId, int CategoryId,
  string AdminId) : IRequest<ActionResult>;
