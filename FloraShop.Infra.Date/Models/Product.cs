using System;
using System.Collections.Generic;

namespace FloraShop.Infra.Data.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int Stock { get; set; }

    public decimal Price { get; set; }

    public DateTime InsertDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<MidorderProduct> MidorderProducts { get; set; } = new List<MidorderProduct>();
}
