using System;
using System.Collections.Generic;

namespace EFDatabaseFirstDemoApi.Domain.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Todo> Todos { get; set; } = new List<Todo>();
}
