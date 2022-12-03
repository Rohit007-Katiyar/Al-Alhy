using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Jersey.Update.Events;

public record UpdateJerseyEvent(int JerseyId, bool IsHome, string AdminId) : IRequest<ActionResult>;
