using BLL.Interfaces;

namespace BLL.DTO;

public class RestaurantDTO : IModel
{
    public string Address { get; set; } = string.Empty;
    public int Revenue { get; set; }
    public int Id { get; set; }
}