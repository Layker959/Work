using System;
using System.Collections.Generic;

namespace Разработка_API__Система_Аэропорта.Models;

public partial class Грузчик
{
    public int КодГрузчика { get; set; }

    public string Фамилия { get; set; } = null!;

    public string Имя { get; set; } = null!;

    public string ОтчествоОтчество { get; set; } = null!;

    public int СтажРаботыЧ { get; set; }

    public int? КодРаботника { get; set; }

    public virtual ICollection<Багаж> Багажs { get; set; } = new List<Багаж>();

    public virtual РаботникАэропорта? КодРаботникаNavigation { get; set; }
}
