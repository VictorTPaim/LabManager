namespace LabManager.Models;

class Lab
{
    public int IdLab { get; set; }
    public int Number { get; set; } 
    public string Name { get; set; }
    public string Block { get; set; }
    
    public Lab(int idLab, int number, string name, string block)
    {
        IdLab = idLab;
        Number = number;
        Name = name;
        Block = block;
    }  
}