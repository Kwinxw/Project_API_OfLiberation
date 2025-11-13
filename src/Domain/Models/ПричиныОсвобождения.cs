using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ПричиныОсвобождения
{
    public int IdПричины { get; set; }

    public string КодПричины { get; set; } = null!;

    public string Название { get; set; } = null!;

    public int МаксДней { get; set; }

    public bool? ТребуетСправку { get; set; }

    public virtual ICollection<Освобождения> Освобожденияs { get; set; } = new List<Освобождения>();
}
