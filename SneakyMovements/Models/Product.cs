using System;
using System.Collections.Generic;

namespace SneakyMovements.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ProductDetailsId { get; set; }

    public bool OnSite { get; set; }

    public bool OnHomePage { get; set; }

    public string? ImageName { get; set; }

    public virtual ProductDetail ProductDetails { get; set; } = null!;
}
