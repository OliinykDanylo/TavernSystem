namespace TavernSystem.Models;

public class ExperienceLevel
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ExperienceLevel(int id, string name)
    {
        Id = id;
        Name = name;
    }
}