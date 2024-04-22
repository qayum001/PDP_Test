using MediatR;
using PDP_Test.Application.Interfaces.Respository;

namespace PDP_Test.Application.Features.Department.Command;

public record CreateDepartmentCommand(string Name, int CompanId, string LocatedCity, int EmployeeCount) : IRequest;

public class CreateDepartmentCommandCommand(IApplicationDbContext context) : IRequestHandler<CreateDepartmentCommand>
{
    public async Task Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var nextId = context.Departments.ToArray().Length + 1;
        var department = Domain.Models.Department.Create(nextId, request.Name, request.CompanId, request.LocatedCity, request.EmployeeCount);

        await context.Departments.AddAsync(department, cancellationToken);
        await context.SaveAsync();
    }
}
