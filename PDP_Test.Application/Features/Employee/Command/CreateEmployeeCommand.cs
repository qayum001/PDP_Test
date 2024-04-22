using MediatR;
using Microsoft.Identity.Client;
using PDP_Test.Application.Interfaces.Respository;

namespace PDP_Test.Application.Features.Employee.Command;

public record CreateEmployeeCommand(string Name, int Salary, string Role, int DepartmentId, int? ManagerId = null) : IRequest;

public class CreateEmployeeCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateEmployeeCommand>
{
    public async Task Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var nextId = context.Employees.ToArray().Length + 1;
        var emploeyy = Domain.Models.Employee.Create(nextId, request.Name, request.Salary, request.Role, request.DepartmentId, request.ManagerId);

        await context.Employees.AddAsync(emploeyy, cancellationToken);
        await context.SaveAsync();
    }
}
