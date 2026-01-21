using System;
using System.Collections.Generic;

namespace QLSP_BE.Data;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public int CategoryId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool IsActive { get; set; } = true;

    public virtual Category Category { get; set; } = null!;
}
