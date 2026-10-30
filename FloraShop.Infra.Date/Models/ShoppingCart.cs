using System;
using System.Collections.Generic;

namespace FloraShop.Infra.Data.Models;

public partial class ShoppingCart
{
    public int Id { get; set; }

    public DateTime InsertDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? ExpireDate { get; set; }

    public virtual ICollection<MidshoppingCartProduct> MidshoppingCartProducts { get; set; } = new List<MidshoppingCartProduct>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
