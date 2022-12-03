using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MomentVideo.GetById.Events;
public record GetMomentVideoByIdEvent(int MomentVideoId, string Lang) : IRequest<ActionResult>;
