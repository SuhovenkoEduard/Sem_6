using BLL.Interfaces;

namespace BLL.DTO;

public class PizzaDTO : IModel
{
    public string Name { get; set; } = string.Empty;
    public int Caloric { get; set; }
    public int Id { get; set; }
}