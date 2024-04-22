using MediatR;
using PDP_Test.Application.Interfaces.Respository;
using System.Collections.Immutable;

namespace PDP_Test.Application.Features.Employee.Queries;

public record GetRegionEmploeyys(string Region) : IRequest<List<Domain.Models.Employee>>;

public class GetRegionEmploeyysHandler(IApplicationDbContext context) : IRequestHandler<GetRegionEmploeyys, List<Domain.Models.Employee>>
{
    public Task<List<Domain.Models.Employee>> Handle(GetRegionEmploeyys request, CancellationToken cancellationToken)
    {
        var dep = context.Departments.Where(e => e.LocatedCity == request.Region).ToList();

        var people = context.Employees.Where(e => dep.Any(x => x.Id == e.Id)).ToList();

        return Task.FromResult(people);
    }
}
