using TavernSystem.Logic;

namespace TavernSystem.Application;

using TavernSystem.Models;

public class AdventurerService : IAdventurerService
{
    private readonly IAdventurerRepository _repository;

    public AdventurerService(IAdventurerRepository repository)
    {
        _repository = repository;
    }

    public List<Adventurer> GetAllAdventurers()
    {
        return _repository.GetAll().ToList();
    }

    public Adventurer? GetAdventurerById(int id)
    {
        return _repository.GetById(id);
    }

    public void Post(Adventurer adventurer)
    {
        _repository.Add(adventurer);
    }
}