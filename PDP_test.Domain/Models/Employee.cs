namespace PDP_Test.Domain.Models;

public class Employee : IEntity
{
    public string Name { get; protected set; }
    public int Salary { get; protected set; }
    public string Role { get; protected set; }
    public int DepartamentId { get; protected set; }
    public int? ManagerId { get; protected set; }

    public int Id { get; protected set; }
    protected Employee() { }

    public static Employee Create(int id, string name, int salary, string role, int departamentId, int? managerId)
    {
        return new Employee()
        {
            Id = id,
            Name = name,
            Salary = salary,
            Role = role,
            DepartamentId = departamentId,
            ManagerId = managerId
        };
    }
}

