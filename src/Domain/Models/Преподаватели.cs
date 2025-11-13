using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Преподаватели
{
    public int IdПреподавателя { get; set; }

    public string Фамилия { get; set; } = null!;

    public string Имя { get; set; } = null!;

    public string? Отчество { get; set; }

    public string? Должность { get; set; }

    public decimal? Ставка { get; set; }

    public virtual ICollection<Нагрузка> Нагрузкаs { get; set; } = new List<Нагрузка>();
}
