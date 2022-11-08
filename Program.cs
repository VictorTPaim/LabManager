using LabManager.Repositories;//importa o Repositories
using LabManager.Models; //Importa o Models
using Microsoft.EntityFrameworkCore;

SystemContext context = new SystemContext();
context.Database.EnsureCreated();

var computerRepository = new ComputerRepository(context);
var labRepository = new LabRepository(context);

var modelName = args[0];
var modelAction = args[1];

if(modelName == "Computer")
{
    if(modelAction == "List")
    {
        Console.WriteLine("Computer List");
        if(computerRepository.GetAll().Count == 0)
        {
            Console.WriteLine("Nenhum computador cadastrado!");
        }
        else{
            foreach (var computer in computerRepository.GetAll())
            {
                Console.WriteLine($"{computer.Id}, {computer.Ram}, {computer.Processor}");
            }
        }
    }

    if(modelAction == "New")
    {
        if(computerRepository.ExistsById(Convert.ToInt32(args[2])))
        {
            Console.WriteLine($"O Computador de id {args[2]} já existe");
        }
        else
        {
            var computer = new Computer(Convert.ToInt32(args[2]), args[3], args[4]);

            computerRepository.Save(computer);
            Console.WriteLine("Computador adicionado!");
        }
    }

    if (modelAction == "Show")
    {
        if(computerRepository.ExistsById(Convert.ToInt32(args[2])))
        {
            var mostrarComputador = computerRepository.GetById(Convert.ToInt32(args[2]));
            Console.WriteLine($"{mostrarComputador.Id}, {mostrarComputador.Ram}, {mostrarComputador.Processor}");
        }
        else
        {
            Console.WriteLine($"O Computador com Id {args[2]} não existe!");
        }
    }

    if (modelAction == "Update")
    {
        if(computerRepository.ExistsById(Convert.ToInt32(args[2])))
        {
            var computer = new Computer(Convert.ToInt32(args[2]), args[3], args[4]);

            computerRepository.Update(computer);
            Console.WriteLine("O Computador foi atualizado!");
        }
        else
        {
            Console.WriteLine($"O Computador com Id {args[2]} não existe!");
        }
    }

    if (modelAction == "Delete")
    {
        if(computerRepository.ExistsById(Convert.ToInt32(args[2])))
        {
            computerRepository.Delete(Convert.ToInt32(args[2]));
            Console.WriteLine($"O Computador com id {args[2]} foi removido!");
        }
        else
        {
            Console.WriteLine($"O Computador com Id {args[2]} não existe!");
        }
    }
}

if(modelName == "Lab")
{
    if(modelAction == "List")
    {
        Console.WriteLine("Lab List");
        if(labRepository.GetAll().Count == 0)
        {
            Console.WriteLine("Nenhum laboratório cadastrado!");
        }
        else
        {
            foreach (var lab in labRepository.GetAll())
            {
                Console.WriteLine($"{lab.Id}, {lab.Number}, {lab.Name}, {lab.Block}");            
            }
        } 
    }

    if(modelAction == "New")
    {
        if(labRepository.ExistsById(Convert.ToInt32(args[2])))
        {
            Console.WriteLine($"O Lab com id {args[2]} já existe!");
        }
        else
        {
            var lab = new Lab(Convert.ToInt32(args[2]), Convert.ToInt32(args[3]), args[4], args[5]);

            labRepository.Save(lab);
            Console.WriteLine("O Lab foi adicionado!");
        }
    }

    if (modelAction == "Show")
    {
        if(labRepository.ExistsById(Convert.ToInt32(args[2])))
        {
            var mostrarLab = labRepository.GetById(Convert.ToInt32(args[2]));
            Console.WriteLine($"{mostrarLab.Id}, {mostrarLab.Number}, {mostrarLab.Name}, {mostrarLab.Block}");
        }
        else
        {
            Console.WriteLine($"O Lab com Id {args[2]} não existe!");
        }
    }

    if (modelAction == "Update")
    {
        if(labRepository.ExistsById(Convert.ToInt32(args[2])))
        {
            var labAtualizado = new Lab(Convert.ToInt32(args[2]), Convert.ToInt32(args[3]), args[4], args[5]);
            labRepository.Update(labAtualizado);
            Console.WriteLine("O Lab foi atualizado!");
        }
        else
        {
            Console.WriteLine($"O Lab com Id {args[2]} não existe");
        }
    }

    if (modelAction == "Delete")
    {
        if(labRepository.ExistsById(Convert.ToInt32(args[2])))
        {
            labRepository.Delete(Convert.ToInt32(args[2]));
            Console.WriteLine($"O Lab com id {args[2]} foi removido!");
        }
        else
        {
            Console.WriteLine($"O Lab com Id {args[2]} não existe!");
        }
    }
}