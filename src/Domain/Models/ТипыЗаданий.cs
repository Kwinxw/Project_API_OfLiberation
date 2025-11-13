using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ТипыЗаданий
{
    public int IdТипаЗадания { get; set; }

    public string КодЗадания { get; set; } = null!;

    public string Название { get; set; } = null!;

    public string? Описание { get; set; }

    public int МаксБалл { get; set; }

    public virtual ICollection<Задания> Заданияs { get; set; } = new List<Задания>();
}
