using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MomentVideo.ChangeStatus.Events;
public record ChangeMomentVideoStatusEvent(int MomentVideoId, string AdminId) : IRequest<ActionResult>;
