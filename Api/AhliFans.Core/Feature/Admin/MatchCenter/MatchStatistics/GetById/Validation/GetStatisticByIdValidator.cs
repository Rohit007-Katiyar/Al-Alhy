using AhliFans.SharedKernel.Interfaces;
using FluentValidation;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics;

public class GetStatisticByIdValidator : AbstractValidator<GetStatisticByIdEvent>
{
    public GetStatisticByIdValidator(IRepository<Entities.MatchStatistic> respository)
    {
        RuleFor(ev => ev.Id)
        .MustAsync(async (id, cancellationToken) => 
        {
            var statistic = await respository.GetByIdAsync(id, cancellationToken);
            return statistic != null;
        })
        .WithMessage("Statistic id is invalid");
    }
}