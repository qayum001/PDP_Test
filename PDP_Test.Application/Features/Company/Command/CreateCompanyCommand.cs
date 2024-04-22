using MediatR;
using PDP_Test.Application.Interfaces.Respository;
using PDP_Test.Domain.Models;

namespace PDP_Test.Application.Features.Company.Command;

public record CreateCompanyCommand(string Name, DateTime FoundedDate, double Revenue) : IRequest;

public class CreateCompanyCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateCompanyCommand>
{
    public async Task Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var nextId = context.Companies.ToArray().Length + 1;
        var company = Domain.Models.Company.Create(nextId, request.Name, request.FoundedDate, request.Revenue);

        await context.Companies.AddAsync(company, cancellationToken);
        await context.SaveAsync();
    }
}
