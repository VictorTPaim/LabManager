using Microsoft.Data.Sqlite; //importar o sqlite
using LabManager.Database; //importa o DatabaseSetup
using LabManager.Repositories;//importa o Repositories

var databaseConfig = new DatabaseConfig();

var DatabaseSetup = new DatabaseSetup(databaseConfig);

var computerRepository = new ComputerRepository(databaseConfig);

var modelName = args[0];
var ModelAction = args[1];

if(modelName == "Computer")
{
    if(ModelAction == "List")
    {
        Console.WriteLine("Computer List");
        //var computers = computerRepository.GetAll();
        foreach (var computer in computerRepository.GetAll())
        {
            //Console.WriteLine("{0}, {1}, {2}", computer.Id, computer.Ram, computer.Processor);
            Console.WriteLine($"{computer.Id}, {computer.Ram}, {computer.Processor}");
        }
    }

    if(ModelAction == "New")
    {
        int id = Convert.ToInt32(args[2]);
        string ram = args[3];
        string processor = args[4];

        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open(); //ABRIR O ARQUIVO/conexão database.db


        var command = connection.CreateCommand(); //comando criado no banco aberto
        command.CommandText = "INSERT INTO Computers VALUES ($id, $ram, $processor)"; //@ - STRING COM QUEBRA DE LINHA
        command.Parameters.AddWithValue("$id", id);
        command.Parameters.AddWithValue("$ram", ram);
        command.Parameters.AddWithValue("$processor", processor);

        command.ExecuteNonQuery(); //create não devolve nada, se fosse select teria retorno
        connection.Close(); // fecha a conexão
    }
}