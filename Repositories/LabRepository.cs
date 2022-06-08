using LabManager.Database;
using LabManager.Models;
using Microsoft.Data.Sqlite;

namespace LabManager.Repositories;

class LabRepository
{
    private readonly DatabaseConfig _databaseConfig;
    public LabRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }
    public List<Lab> GetAll()
    {
        var labs = new List<Lab>();

        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open(); //ABRIR O ARQUIVO/conexão database.db

        var command = connection.CreateCommand(); //comando criado no banco aberto
        command.CommandText = "SELECT * FROM Labs";

        var reader = command.ExecuteReader(); //representa o resultado da tabela

        while(reader.Read())
        {
            var lab = ReaderToLab(reader); 
            labs.Add(lab);
        }

        connection.Close(); //fecha a conexão

        return labs;
    }

    public Computer Save(Computer computer)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);

        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Computers VALUES($id, $ram, $processor)";
        command.Parameters.AddWithValue("$id", computer.Id);
        command.Parameters.AddWithValue("$ram", computer.Ram);
        command.Parameters.AddWithValue("$processor", computer.Processor);

        command.ExecuteNonQuery();
        connection.Close();

        return computer;
    }

    public Computer GetById(int id)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Computers WHERE id = ($id)";
        command.Parameters.AddWithValue("$id", id);

        var reader = command.ExecuteReader();
        reader.Read();

        var ram = reader.GetString(1);
        var processor = reader.GetString(2);
        var computer = new Computer(id, ram, processor);

        connection.Close();

        return computer; 
    }

    public Computer Update(Computer computer)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "UPDATE Computers SET ram = $ram, processor = $processor WHERE id = $id";
        command.Parameters.AddWithValue("$id", computer.Id);
        command.Parameters.AddWithValue("$ram", computer.Ram);
        command.Parameters.AddWithValue("$processor", computer.Processor);

        command.ExecuteNonQuery();
        connection.Close();

        return computer;
    }

    public void Delete(int id)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM Computers WHERE id = ($id)";
        command.Parameters.AddWithValue("$id", id);

        command.ExecuteNonQuery();
        connection.Close();
    }

    private Lab ReaderToLab(SqliteDataReader reader)
    {
        var lab = new Lab(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3));

        return lab;
    }
}