using System;
using System.Collections.Generic;

namespace Разработка_API__Система_Аэропорта.Models;

public partial class РучнаяКладь
{
    public int ВысотаСм { get; set; }

    public int ШиринаСм { get; set; }

    public int ДлинаСм { get; set; }

    public double ВесБагажа { get; set; }

    public int КодТалонаБагажа { get; set; }

    public int КодТаможенника { get; set; }

    public virtual ТалонБагажа КодТалонаБагажаNavigation { get; set; } = null!;

    public virtual Таможенник КодТаможенникаNavigation { get; set; } = null!;
}
