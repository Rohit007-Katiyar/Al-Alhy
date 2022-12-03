using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.Title.Add.Events;

public record AddTitleEvent(string Text, string TextAr) : IRequest<ActionResult>;
