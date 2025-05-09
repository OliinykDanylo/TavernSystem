using Microsoft.AspNetCore.Mvc;
using TavernSystem.Logic;
using TavernSystem.Models;

namespace TavernSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdventurersController : ControllerBase
{
    private readonly IAdventurerService _service;

    public AdventurersController(IAdventurerService service)
    {
        _service = service;
    }

    [HttpGet]
    public IResult GetAll()
    {
        var adventurers = _service.GetAllAdventurers();
        return Results.Ok(adventurers);
    }

    [HttpGet("{id}")]
    public IResult GetById(int id)
    {
        var adventurer = _service.GetAdventurerById(id);
        return adventurer is not null ? Results.Ok(adventurer) : Results.NotFound($"Adventurer with ID {id} not found.");
    }

    [HttpPost]
    public IResult Post([FromBody] Adventurer adventurer)
    {
        _service.Post(adventurer);
        return Results.Created($"/api/adventurers/{adventurer.Id}", adventurer);
    }
}