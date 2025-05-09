namespace TavernSystem.Logic;

using Microsoft.Data.SqlClient;
using TavernSystem.Models;

public class AdventurerRepository : IAdventurerRepository
{
    private readonly string _connectionString;

    public AdventurerRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IEnumerable<Adventurer> GetAll()
    {
        var adventurers = new List<Adventurer>();

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        string query = "SELECT Id, Nickname, RaceId, ExperienceId, PersonId FROM Adventurer";
        using var command = new SqlCommand(query, connection);
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            adventurers.Add(new Adventurer(
                (int)reader["Id"],
                reader["Nickname"].ToString()!,
                (int)reader["RaceId"],
                (int)reader["ExperienceId"],
                reader["PersonId"].ToString()!
            ));
        }

        return adventurers;
    }

    public Adventurer? GetById(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        string query = "SELECT Id, Nickname, RaceId, ExperienceId, PersonId FROM Adventurer WHERE Id = @Id";
        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Id", id);

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return new Adventurer(
                (int)reader["Id"],
                reader["Nickname"].ToString()!,
                (int)reader["RaceId"],
                (int)reader["ExperienceId"],
                reader["PersonId"].ToString()!
            );
        }

        return null;
    }

    public void Add(Adventurer adventurer)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        string query = @"
            INSERT INTO Adventurer (Nickname, RaceId, ExperienceId, PersonId)
            VALUES (@Nickname, @RaceId, @ExperienceId, @PersonId)";
        
        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Nickname", adventurer.Nickname);
        command.Parameters.AddWithValue("@RaceId", adventurer.RaceId);
        command.Parameters.AddWithValue("@ExperienceId", adventurer.ExperienceId);
        command.Parameters.AddWithValue("@PersonId", adventurer.PersonId);

        command.ExecuteNonQuery();
    }
}