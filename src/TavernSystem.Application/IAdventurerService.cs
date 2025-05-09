using TavernSystem.Models;

namespace TavernSystem.Logic;

public interface IAdventurerService
{
    List<Adventurer> GetAllAdventurers();
    Adventurer? GetAdventurerById(int id);
    void Post(Adventurer adventurer);
}