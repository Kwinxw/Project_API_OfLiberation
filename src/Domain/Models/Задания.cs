using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Задания
{
    public int IdЗадания { get; set; }

    public int IdОсвобождения { get; set; }

    public int IdТипаЗадания { get; set; }

    public DateOnly ДатаНазначения { get; set; }

    public DateOnly СрокСдачи { get; set; }

    public string Тема { get; set; } = null!;

    public string? Описание { get; set; }

    public virtual Освобождения IdОсвобожденияNavigation { get; set; } = null!;

    public virtual ТипыЗаданий IdТипаЗаданияNavigation { get; set; } = null!;

    public virtual Оценки? Оценки { get; set; }
}
