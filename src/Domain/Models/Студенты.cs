using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Студенты
{
    public int IdСтудента { get; set; }

    public string Фамилия { get; set; } = null!;

    public string Имя { get; set; } = null!;

    public string? Отчество { get; set; }

    public int IdГруппы { get; set; }

    public string НомерЗачетки { get; set; } = null!;

    public string? Телефон { get; set; }

    public string? Email { get; set; }

    public DateTime? ДатаРегистрации { get; set; }

    public virtual Группы IdГруппыNavigation { get; set; } = null!;

    public virtual ICollection<Освобождения> Освобожденияs { get; set; } = new List<Освобождения>();
}
