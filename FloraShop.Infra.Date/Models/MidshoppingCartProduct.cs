using System;
using System.Collections.Generic;

namespace FloraShop.Infra.Data.Models;

public partial class MidshoppingCartProduct
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int ShoppingCartId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual ShoppingCart ShoppingCart { get; set; } = null!;
}
