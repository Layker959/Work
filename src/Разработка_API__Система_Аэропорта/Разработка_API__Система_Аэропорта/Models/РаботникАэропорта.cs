using System;
using System.Collections.Generic;

namespace Разработка_API__Система_Аэропорта.Models;

public partial class РаботникАэропорта
{
    public int КолВоОтработаныхЧасов { get; set; }

    public int ПочасоваяОплата { get; set; }

    public int КодРаботника { get; set; }

    public virtual ICollection<Грузчик> Грузчикs { get; set; } = new List<Грузчик>();

    public virtual ICollection<Диспечер> Диспечерs { get; set; } = new List<Диспечер>();

    public virtual ICollection<ИнженерМеханик> ИнженерМеханикs { get; set; } = new List<ИнженерМеханик>();

    public virtual ICollection<Охрана> Охранаs { get; set; } = new List<Охрана>();

    public virtual ICollection<Пограничник> Пограничникs { get; set; } = new List<Пограничник>();

    public virtual ICollection<Таможенник> Таможенникs { get; set; } = new List<Таможенник>();
}
