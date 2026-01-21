using System;
using System.Collections.Generic;

namespace QLSP_BE.Data;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool IsActive { get; set; } = true;


    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
