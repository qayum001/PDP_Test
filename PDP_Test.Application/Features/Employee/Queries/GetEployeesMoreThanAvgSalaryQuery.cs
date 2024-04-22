using MediatR;
using PDP_Test.Application.Interfaces.Respository;

namespace PDP_Test.Application.Features.Employee.Queries;


public record GetEployeesMoreThanAvgSalaryQuery : IRequest<List<Domain.Models.Employee>>;

public class GetEployeesMoreThanAvgSalaryQueryHandler(IApplicationDbContext context) : IRequestHandler<GetEployeesMoreThanAvgSalaryQuery, List<Domain.Models.Employee>>
{
    public Task<List<Domain.Models.Employee>> Handle(GetEployeesMoreThanAvgSalaryQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
