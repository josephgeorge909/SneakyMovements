using System;
using System.Collections.Generic;

namespace SneakyMovements.Models;

public partial class ProductDetail
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
