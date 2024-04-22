using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using PDP_Test.Application.Interfaces.Respository;

namespace PDP_Test.Application.Features.Department.Query;

public record GetDepsThatAvgSalaryHighByGivenQuery(string DepName) : IRequest<List<Domain.Models.Department>>;

public class GetDepsThatAvgSalaryHighByGivenQueryHandler(IApplicationDbContext context) : 
    IRequestHandler<GetDepsThatAvgSalaryHighByGivenQuery, List<Domain.Models.Department>>
{
    public async Task<List<Domain.Models.Department>> Handle(GetDepsThatAvgSalaryHighByGivenQuery request, CancellationToken cancellationToken)
    {
        var givenDep = await context.Departments.FirstAsync(e => e.Name == request.DepName, cancellationToken: cancellationToken);

        var avgSalary = context.Employees.Where(e => e.DepartamentId == givenDep.Id).Select(e => e.Salary / 2).Sum();

        var res = new List<Domain.Models.Department>();
        foreach (var item in context.Departments)
        {
            var currentAvgSalary = context.Employees.Where(e => e.DepartamentId == givenDep.Id).Select(e => e.Salary / 2).Sum();

            if (currentAvgSalary > avgSalary)
                res.Add(item);
        }

        return res;
    }
}
