using System.ComponentModel.DataAnnotations;
using DAL.Interfaces;

namespace DAL.Entities;

public class Cook : IEntity
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public int PizzaId { get; set; }
    public int RestaurantId { get; set; }

    public virtual Pizza Pizza { get; set; } = new();
    public virtual Restaurant Restaurant { get; set; } = new();

    [Key] public int Id { get; set; }
}