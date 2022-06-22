using Microsoft.Data.Sqlite; //importar o sqlite
using LabManager.Database; //importa o DatabaseSetup
using LabManager.Repositories;//importa o Repositories
using LabManager.Models; //Importa o Models

var databaseConfig = new DatabaseConfig();

var DatabaseSetup = new DatabaseSetup(databaseConfig);

var computerRepository = new ComputerRepository(databaseConfig);

var labRepository = new LabRepository(databaseConfig);

var modelName = args[0];
var modelAction = args[1];

if(modelName == "Computer")
{
    if(modelAction == "List")
    {
        Console.WriteLine("Computer List");
        //var computers = computerRepository.GetAll();
        foreach (var computer in computerRepository.GetAll())
        {
            //Console.WriteLine("{0}, {1}, {2}", computer.Id, computer.Ram, computer.Processor);
            Console.WriteLine($"{computer.Id}, {computer.Ram}, {computer.Processor}");
        }
    }

    if(modelAction == "New")
    {
        int id = Convert.ToInt32(args[2]);
        string ram = args[3];
        string processor = args[4];

        var computer = new Computer(id, ram, processor);
        if(computerRepository.ExistsById(id))
        {
            Console.WriteLine("O computador com este ID ja existe!");
        }else
        {
            computerRepository.Save(computer);
            Console.WriteLine("Computador criado!");
        }
    }

    if (modelAction == "Show")
    {
        var id = Convert.ToInt32(args[2]);

        if(computerRepository.ExistsById(id))
        {
            var computer = computerRepository.GetById(id);
            Console.WriteLine($"{computer.Id}, {computer.Ram}, {computer.Processor}");
        }else
        {
            Console.WriteLine($"O computador com id {id} não existe!");
        }
    }

    if (modelAction == "Update")
    {
        var id = Convert.ToInt32(args[2]);
        
        if(computerRepository.ExistsById(id))
        {
            var ram = args[3];
            var processor = args[4];

            var computer = new Computer(id, ram, processor);

            computerRepository.Update(computer);

            Console.WriteLine("O computador foi atualizado!");
        }else
        {
            Console.WriteLine($"O computador com id {id} não existe!");
        }
    }

    if (modelAction == "Delete")
    {
        var id = Convert.ToInt32(args[2]);

        if(computerRepository.ExistsById(id))
        {
            computerRepository.Delete(id);
            Console.WriteLine("O computador foi deletado!");
        }else
        {
            Console.WriteLine($"O computador com id {id} não existe!");
        }
    }
}

if(modelName == "Lab")
{
    if(modelAction == "List")
    {
        Console.WriteLine("Lab List");
        //var labs = labRepository.GetAll();
        foreach (var lab in labRepository.GetAll())
        {
            //Console.WriteLine("{0}, {1}, {2}", computer.Id, computer.Ram, computer.Processor);
            Console.WriteLine($"{lab.Id}, {lab.Number}, {lab.Name}, {lab.Block}");
        }
    }

    if(modelAction == "New")
    {
        int id = Convert.ToInt32(args[2]);
        int number = Convert.ToInt32(args[3]);
        string name = args[4];
        string block = args[5];

        var lab = new Lab(id, number, name, block);
        if(labRepository.ExistsById(id))
        {
            Console.WriteLine("O laboratorio com este ID já existe!");
        }else
        {
            labRepository.Save(lab);
            Console.WriteLine("Laboratorio criado!");
        }
    }

    if (modelAction == "Show")
    {
        var id = Convert.ToInt32(args[2]);

        if(labRepository.ExistsById(id))
        {
            var lab = labRepository.GetById(id);
            Console.WriteLine($"{lab.Id}, {lab.Number}, {lab.Name}, {lab.Block}");
        }else
        {
            Console.WriteLine($"O laboratório com id {id} não existe!");
        }
    }

    if (modelAction == "Update")
    {
        var id = Convert.ToInt32(args[2]);

        if(labRepository.ExistsById(id))
        {
            var number = Convert.ToInt32(args[3]);
            var name = args[4];
            var block = args[5];
            var lab = new Lab(id, number, name, block);
            labRepository.Update(lab);
            
            Console.WriteLine("O laboratório foi atualizado");
        }else
        {
            Console.WriteLine($"O laboratório com id {id} não existe!");
        }
    }

    if (modelAction == "Delete")
    {
        var id = Convert.ToInt32(args[2]);

        if(labRepository.ExistsById(id))
        {
            labRepository.Delete(id);

            Console.WriteLine("O laboratório foi deletado");
        }else
        {
            Console.WriteLine($"O laboratório com id {id} não existe!");
        }
    }
}