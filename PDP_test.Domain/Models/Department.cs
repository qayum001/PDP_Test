namespace PDP_Test.Domain.Models;

public class Department : IEntity
{
    public int Id { get; protected set; }
    public string Name { get; protected set; }
    public int CompanyId { get; protected set; }
    public string LocatedCity { get; protected set; }
    public int EmployeeCount { get; protected set; }

    protected Department() { }

    public static Department Create(int id, string name, int companyId, string locatedCity, int employeeCount)
    {
        return new Department()
        {
            Id = id,
            Name = name,
            CompanyId = companyId,
            LocatedCity = locatedCity,
            EmployeeCount = employeeCount
        };
    }
}
