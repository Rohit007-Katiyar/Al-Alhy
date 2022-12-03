using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.NormalVideo.GetById.Events;
public record GetNormalVideoByIdEvent(int NormalVideoId, string Lang) : IRequest<ActionResult>;
