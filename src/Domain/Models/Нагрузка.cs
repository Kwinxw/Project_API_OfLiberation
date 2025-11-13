using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Нагрузка
{
    public int IdНагрузки { get; set; }

    public int IdПреподавателя { get; set; }

    public int IdГруппы { get; set; }

    public int Семестр { get; set; }

    public int УчебныйГод { get; set; }

    public virtual Группы IdГруппыNavigation { get; set; } = null!;

    public virtual Преподаватели IdПреподавателяNavigation { get; set; } = null!;
}
