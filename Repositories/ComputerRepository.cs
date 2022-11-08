using LabManager.Models;
using Microsoft.EntityFrameworkCore;

namespace LabManager.Repositories;

class ComputerRepository
{
    SystemContext context = new SystemContext();
    public ComputerRepository(SystemContext contexto)
    {
        this.context = contexto;
    }
    public List<Computer> GetAll()
    {
        return context.Computers.ToList();
    }


    public Computer Save(Computer computer)
    {
        context.Computers.Add(computer);
        context.SaveChanges();
        return computer;
    }

    public Computer GetById(int id)
    {
        return context.Computers.Find(id);
    }

    public Computer Update(Computer computer)
    {
        Computer computadorAtualizado = context.Computers.Find(computer.Id);

        computadorAtualizado.Ram = computer.Ram;
        computadorAtualizado.Processor = computer.Processor;

        context.Computers.Update(computadorAtualizado);
        context.SaveChanges();
        return computer;
    }

    public void Delete(int id)
    {
        context.Computers.Remove(context.Computers.Find(id));
        context.SaveChanges();
    }

    public bool ExistsById(int id)
    {
        if(context.Computers.ToList().Contains(GetById(id))){
            return true;
        }
        return false;
    }
}