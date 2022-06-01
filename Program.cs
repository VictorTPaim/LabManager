using Microsoft.Data.Sqlite; //importar o sqlite
using LabManager.Database; //importa o DatabaseSetup
using LabManager.Repositories;//importa o Repositories
using LabManager.Models; //Importa o Models

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

        var computer = new Computer(id, ram, processor);

        computerRepository.Save(computer);
    }

    if (ModelAction == "Show")
    {
        var id = Convert.ToInt32(args[2]);
        var computer = computerRepository.GetById(id);
        Console.WriteLine($"{computer.Id}, {computer.Ram}, {computer.Processor}");
    }

    if (ModelAction == "Update")
    {
        var id = Convert.ToInt32(args[2]);
        var ram = args[3];
        var processor = args[4];

        var computer = new Computer(id, ram, processor);

        computerRepository.Update(computer);
    }
}