using BLL.Interfaces;

namespace BLL.DTO;

public class CookDTO : IModel
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public int PizzaId { get; set; }
    public int RestaurantId { get; set; }
    public int Id { get; set; }
}