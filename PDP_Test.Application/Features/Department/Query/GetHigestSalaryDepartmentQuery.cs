using MediatR;
using Microsoft.EntityFrameworkCore;
using PDP_Test.Application.Interfaces.Respository;

namespace PDP_Test.Application.Features.Department.Query;

public record GetHigestSalaryDepartmentQuery : IRequest<Domain.Models.Department>;

public class GetHigestSalaryDepartmentQueryHandler(IApplicationDbContext context) : IRequestHandler<GetHigestSalaryDepartmentQuery, Domain.Models.Department>
{
    public async Task<Domain.Models.Department> Handle(GetHigestSalaryDepartmentQuery request, CancellationToken cancellationToken)
    {
        var departments = context.Departments.ToList();

        var richest = await context.Employees.MaxAsync(e => e.Salary, cancellationToken);

        var emploeyy = await context.Employees.FirstAsync(e => e.Salary == richest);

        return context.Departments.First(e => e.Id == emploeyy.DepartamentId);
    }
}
