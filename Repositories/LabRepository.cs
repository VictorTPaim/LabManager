using LabManager.Models;
using Microsoft.EntityFrameworkCore;

namespace LabManager.Repositories;

class LabRepository
{
    SystemContext context = new SystemContext();
    public LabRepository(SystemContext contexto)
    {
        this.context = contexto;
    }
    public List<Lab> GetAll()
    {
        return context.Labs.ToList();
    }

    public Lab Save(Lab lab)
    {
        context.Labs.Add(lab);
        context.SaveChanges();
        return lab;
    }

    public Lab GetById(int id)
    {
        return context.Labs.Find(id);
    }

    public Lab Update(Lab lab)
    {
        Lab labAtualizado = context.Labs.Find(lab.Id);

        labAtualizado.Number = lab.Number;
        labAtualizado.Name = lab.Name;
        labAtualizado.Block = lab.Block;

        context.Labs.Update(labAtualizado);
        context.SaveChanges();
        return lab;
    }

    public void Delete(int id)
    {
       context.Labs.Remove(context.Labs.Find(id));
        context.SaveChanges();
    }

    public bool ExistsById(int id)
    {
        if(context.Labs.ToList().Contains(GetById(id))){
            return true;
        }
        return false;
    }
}