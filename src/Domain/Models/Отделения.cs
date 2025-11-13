using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Отделения
{
    public int IdОтделения { get; set; }

    public string Название { get; set; } = null!;

    public string? Заведующий { get; set; }

    public DateTime? ДатаСоздания { get; set; }

    public virtual ICollection<Специальности> Специальностиs { get; set; } = new List<Специальности>();
}
