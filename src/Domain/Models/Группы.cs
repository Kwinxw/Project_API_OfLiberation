using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Группы
{
    public int IdГруппы { get; set; }

    public string Название { get; set; } = null!;

    public int IdСпециальности { get; set; }

    public int Курс { get; set; }

    public int ГодПоступления { get; set; }

    public virtual Специальности IdСпециальностиNavigation { get; set; } = null!;

    public virtual ICollection<Нагрузка> Нагрузкаs { get; set; } = new List<Нагрузка>();

    public virtual ICollection<Студенты> Студентыs { get; set; } = new List<Студенты>();
}
