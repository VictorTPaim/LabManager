using LabManager.Models;
using Microsoft.Data.Sqlite;

namespace LabManager.Repositories;

class ComputerRepository
{
    public List<Computer> GetAll()
    {
        var computers = new List<Computer>();

        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open(); //ABRIR O ARQUIVO/conexão database.db

        var command = connection.CreateCommand(); //comando criado no banco aberto
        command.CommandText = "SELECT * FROM Computers";

        var reader = command.ExecuteReader(); //representa o resultado da tabela

        while(reader.Read())
        {
            //cria as variáveis id, ram e processor. Recebem a posição do reader, sendo (0) a primeira coisa da lista, o id, (1) a segunda, ram, e (2) processor.
            var id = reader.GetInt32(0);
            var ram = reader.GetString(1);
            var processor = reader.GetString(2);
            var computer = new Computer(id, ram, processor); 
            computers.Add(computer);
            
        }

        connection.Close(); //fecha a conexão

        return computers;
    }
}