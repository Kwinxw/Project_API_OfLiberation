using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Оценки
{
    public int IdОценки { get; set; }

    public int IdЗадания { get; set; }

    public int Балл { get; set; }

    public DateOnly ДатаСдачи { get; set; }

    public string? Комментарий { get; set; }

    public string Преподаватель { get; set; } = null!;

    public DateTime? ДатаОценки { get; set; }

    public virtual Задания IdЗаданияNavigation { get; set; } = null!;
}
