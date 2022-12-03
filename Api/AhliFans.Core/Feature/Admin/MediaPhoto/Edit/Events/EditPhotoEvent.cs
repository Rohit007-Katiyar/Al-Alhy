using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MediaPhoto.Edit.Events;
public record EditPhotoEvent(int PhotoId, int SeasonId, string Month, string PhotoLink,
  int MatchId, int LeagueId, string Description, string DescriptionAr, int? PlayerId, int? CoachId, int CategoryId, bool? IsExclusiveContent,
  string AdminId) : IRequest<ActionResult>;
