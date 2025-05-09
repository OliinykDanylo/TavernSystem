using TavernSystem.Models;

public interface IAdventurerRepository
{
    IEnumerable<Adventurer> GetAll();
    Adventurer? GetById(int id);
    void Add(Adventurer adventurer);
}