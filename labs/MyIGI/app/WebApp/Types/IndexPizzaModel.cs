namespace WebApp.Types;

public class IndexPizzaModel
{
    public List<BLL.DTO.PizzaDTO>? Pizzas { get; set; }
    public string? Filter { get; set; }
}