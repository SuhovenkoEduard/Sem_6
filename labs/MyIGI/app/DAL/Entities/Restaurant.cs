using System.ComponentModel.DataAnnotations;
using DAL.Interfaces;

namespace DAL.Entities;

public class Restaurant : IEntity
{
    public Restaurant()
    {
        Cooks = new HashSet<Cook>();
    }

    public string Address { get; set; } = string.Empty;
    public int Revenue { get; set; }

    public virtual ICollection<Cook> Cooks { get; set; }

    [Key] public int Id { get; set; }
}