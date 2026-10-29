using System;
using System.Collections.Generic;

namespace FloraShop.Infra.Data.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateTime InsertDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string Status { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public virtual ICollection<MidorderProduct> MidorderProducts { get; set; } = new List<MidorderProduct>();
}
