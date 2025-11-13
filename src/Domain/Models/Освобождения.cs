using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Освобождения
{
    public int IdОсвобождения { get; set; }

    public int IdСтудента { get; set; }

    public int IdПричины { get; set; }

    public DateOnly ДатаНачала { get; set; }

    public DateOnly ДатаОкончания { get; set; }

    public string? НомерСправки { get; set; }

    public string? КемВыдано { get; set; }

    public string? Примечание { get; set; }

    public DateTime? ДатаСоздания { get; set; }

    public virtual ПричиныОсвобождения IdПричиныNavigation { get; set; } = null!;

    public virtual Студенты IdСтудентаNavigation { get; set; } = null!;

    public virtual ICollection<Задания> Заданияs { get; set; } = new List<Задания>();
}
