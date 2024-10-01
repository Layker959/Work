using System;
using System.Collections.Generic;

namespace Разработка_API__Система_Аэропорта.Models;

public partial class Багаж
{
    public int Высота { get; set; }

    public int ШиринаСм { get; set; }

    public int ДлинаСм { get; set; }

    public double ВесБагажаКг { get; set; }

    public int КодТалонаБагажа { get; set; }

    public int КодГрузчика { get; set; }

    public int КодТаможенника { get; set; }

    public virtual Грузчик КодГрузчикаNavigation { get; set; } = null!;

    public virtual ТалонБагажа КодТалонаБагажаNavigation { get; set; } = null!;

    public virtual Таможенник КодТаможенникаNavigation { get; set; } = null!;
}
