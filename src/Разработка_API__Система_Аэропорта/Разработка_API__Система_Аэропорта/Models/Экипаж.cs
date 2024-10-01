using System;
using System.Collections.Generic;

namespace Разработка_API__Система_Аэропорта.Models;

public partial class Экипаж
{
    public int КодЭкипажа { get; set; }

    public int КолВоНалётанныхЧасов { get; set; }

    public int ПочасоваяОплата { get; set; }

    public int КодКомандира { get; set; }

    public int КодПилота { get; set; }

    public virtual ICollection<Бортпроводник> Бортпроводникs { get; set; } = new List<Бортпроводник>();

    public virtual Командир КодКомандираNavigation { get; set; } = null!;

    public virtual Пилот КодПилотаNavigation { get; set; } = null!;

    public virtual ICollection<Самолёт> Самолётs { get; set; } = new List<Самолёт>();
}
