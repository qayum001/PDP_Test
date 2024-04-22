using MediatR;
using PDP_Test.Application.Interfaces.Respository;

namespace PDP_Test.Application.Features.Employee.Queries;

public record GetEmployeesByRolesQuery(List<string> Roles) : IRequest<List<Domain.Models.Employee>>;

public class GetEmployeesByRolesQueryHandler(IApplicationDbContext context) : IRequestHandler<GetEmployeesByRolesQuery, List<Domain.Models.Employee>>
{
    public Task<List<Domain.Models.Employee>> Handle(GetEmployeesByRolesQuery request, CancellationToken cancellationToken)
    {
        var res = context.Employees.Where(e => request.Roles.Contains(e.Role));
        return Task.FromResult(res.ToList());
    }
}
