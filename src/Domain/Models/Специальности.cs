using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Специальности
{
    public int IdСпециальности { get; set; }

    public string КодСпециальности { get; set; } = null!;

    public string Название { get; set; } = null!;

    public int IdОтделения { get; set; }

    public virtual Отделения IdОтделенияNavigation { get; set; } = null!;

    public virtual ICollection<Группы> Группыs { get; set; } = new List<Группы>();
}
