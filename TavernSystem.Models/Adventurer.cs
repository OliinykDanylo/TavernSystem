namespace TavernSystem.Models;

public class Adventurer
{
    public int Id { get; set; }
    public string Nickname { get; set; }
    public int RaceId { get; set; }
    public int ExperienceId { get; set; }
    public string PersonId { get; set; }

    public Adventurer(int id, string nickname, int raceId, int experienceId, string personId)
    {
        Id = id;
        Nickname = nickname;
        RaceId = raceId;
        ExperienceId = experienceId;
        PersonId = personId;
    }

    public bool HasBounty(Person person)
    {
        return int.TryParse(PersonId, out var personId) && person.Id == personId && person.HasBounty;
    }
    
}