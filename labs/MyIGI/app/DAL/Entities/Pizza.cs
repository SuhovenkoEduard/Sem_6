using System.ComponentModel.DataAnnotations;
using DAL.Interfaces;

namespace DAL.Entities;

public class Pizza : IEntity
{
    public Pizza()
    {
        Cooks = new HashSet<Cook>();
    }
    
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Caloric { get; set; }
    
    public ICollection<Cook> Cooks { get; set; }
}