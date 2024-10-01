using System;
using System.Collections.Generic;

namespace Разработка_API__Система_Аэропорта.Models;

public partial class Пилот
{
    public int КодПилота { get; set; }

    public string Фамилия { get; set; } = null!;

    public string Имя { get; set; } = null!;

    public string Отчество { get; set; } = null!;

    public int СтажРаботыЧ { get; set; }

    public virtual ICollection<Экипаж> Экипажs { get; set; } = new List<Экипаж>();
}
