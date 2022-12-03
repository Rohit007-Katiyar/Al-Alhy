using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Jersey.ChangeStatus.Events;
public record ChangeJerseyStatusEvent(int JerseyId, string AdminId) : IRequest<ActionResult>;
