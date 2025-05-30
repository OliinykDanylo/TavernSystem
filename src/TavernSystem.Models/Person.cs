namespace TavernSystem.Models;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public bool HasBounty { get; set; }

    public Person(int id, string firstName, string middleName, string lastName, bool hasBounty)
    {
        Id = id;
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
        HasBounty = hasBounty;
    }
    
    
}