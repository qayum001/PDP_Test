namespace PDP_Test.Domain.Models;

public class Company : IEntity
{
    public int Id { get; protected set; }
    public string Name { get; protected set; } 
    public DateTime FundedDate { get; protected set; } 
    public double Revenue { get; protected set; }

    private Company() { }

    public static Company Create(int id, string name, DateTime foundedDate, double revenue)
    {
        return new Company()
        {
            Id = id,
            Name = name,
            FundedDate = foundedDate,
            Revenue = revenue
        };
    }
}
