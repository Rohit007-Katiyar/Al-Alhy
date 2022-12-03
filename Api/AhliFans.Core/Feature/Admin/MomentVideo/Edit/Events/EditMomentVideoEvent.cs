﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MomentVideo.Edit.Events;
public record EditMomentVideoEvent(int MomentVideoId, int SeasonId, string Month, string VideoURL,
  int MatchId, int LeagueId, string Description, string DescriptionAr, int PlayerId, string VideoType, int Time, int CategoryId,
  string AdminId) : IRequest<ActionResult>;