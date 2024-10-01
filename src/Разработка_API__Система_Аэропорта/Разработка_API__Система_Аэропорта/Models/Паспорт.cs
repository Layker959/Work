using System;
using System.Collections.Generic;

namespace Разработка_API__Система_Аэропорта.Models;

public partial class Паспорт
{
    public string Фамилия { get; set; } = null!;

    public string Имя { get; set; } = null!;

    public string Отчество { get; set; } = null!;

    public int СерияНомер { get; set; }

    public string КемВыдан { get; set; } = null!;

    public int КодПассажира { get; set; }

    public int КодОхранника { get; set; }

    public int КодПограничника { get; set; }

    public virtual Охрана КодОхранникаNavigation { get; set; } = null!;

    public virtual Пассажир КодПассажираNavigation { get; set; } = null!;

    public virtual Пограничник КодПограничникаNavigation { get; set; } = null!;
}
