using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.NormalVideo.ChangeStatus.Events;
public record ChangeNormalVideoStatusEvent(int normalVideoId, string AdminId) : IRequest<ActionResult>;
