using System;
using System.Collections.Generic;

namespace Разработка_API__Система_Аэропорта.Models;

public partial class Пассажир
{
    public string Фамилия { get; set; } = null!;

    public string Имя { get; set; } = null!;

    public string Отчество { get; set; } = null!;

    public string Пол { get; set; } = null!;

    public DateOnly ДатаРождения { get; set; }

    public string Категория { get; set; } = null!;

    public int КодПассажира { get; set; }

    public int КодСамолёта { get; set; }

    public int КодКомандира { get; set; }

    public int КодПилота { get; set; }

    public int? Attribute1 { get; set; }

    public virtual ICollection<Билет> Билетs { get; set; } = new List<Билет>();

    public virtual ICollection<Бортпроводник> Бортпроводникs { get; set; } = new List<Бортпроводник>();

    public virtual ICollection<Паспорт> Паспортs { get; set; } = new List<Паспорт>();

    public virtual Самолёт? Самолёт { get; set; }

    public virtual ICollection<ТалонБагажа> ТалонБагажаs { get; set; } = new List<ТалонБагажа>();
}
