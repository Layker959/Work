using System;
using System.Collections.Generic;

namespace Разработка_API__Система_Аэропорта.Models;

public partial class Командир
{
    public int КодКомандира { get; set; }

    public string Фамилия { get; set; } = null!;

    public string Имя { get; set; } = null!;

    public string Отчество { get; set; } = null!;

    public int СтажРаботыЧ { get; set; }

    public int КодДиспечера { get; set; }

    public virtual Диспечер КодДиспечераNavigation { get; set; } = null!;

    public virtual ICollection<Экипаж> Экипажs { get; set; } = new List<Экипаж>();
}
