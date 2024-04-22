using MediatR;
using PDP_Test.Application.Interfaces.Respository;

namespace PDP_Test.Application.Features.Department.Query;

public record GetDepartmentBySalaryLevel(int Level) : IRequest<List<Domain.Models.Department>>;

public class GetDepartmentBySalaryLevelHandler(IApplicationDbContext context) : IRequestHandler<GetDepartmentBySalaryLevel, List<Domain.Models.Department>>
{
    public Task<List<Domain.Models.Department>> Handle(GetDepartmentBySalaryLevel request, CancellationToken cancellationToken)
    {
        var deps = context.Departments.ToList();

        var res = new List<Domain.Models.Department>();

        foreach (var item in deps)
        {
            var users = context.Employees.Where(e => e.DepartamentId == item.Id);
            if (users.Sum(e => e.Salary) > request.Level)
                res.Add(item);
        }

        return Task.FromResult(res);
    }
}
