namespace SneakyMovements.ViewModels;

public class ProductDetailVm
{
    public string Name { get; set; }
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string ImageName { get; set; }
}