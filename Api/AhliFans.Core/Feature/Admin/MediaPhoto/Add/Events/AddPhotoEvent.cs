using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MediaPhoto.Add.Events;
public record AddPhotoEvent(int SeasonId, string Month, string? PhotoLink, 
  int MatchId,int LeagueId, string Description,string DescriptionAr, int? PlayerId, int? CoachId, int CategoryId, bool? IsExclusiveContent,
  IFormFile? Photo, string AdminId) : IRequest<ActionResult>;
