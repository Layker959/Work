using System;
using System.Collections.Generic;

namespace Разработка_API__Система_Аэропорта.Models;

public partial class Рассписание
{
    public DateOnly Дата { get; set; }

    public TimeOnly Время { get; set; }

    public int КодСамолёта { get; set; }

    public int КодКомандира { get; set; }

    public int КодПилота { get; set; }

    public int Attribute1 { get; set; }

    public virtual Самолёт Самолёт { get; set; } = null!;
}
