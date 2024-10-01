using System;
using System.Collections.Generic;

namespace Разработка_API__Система_Аэропорта.Models;

public partial class Бортпроводник
{
    public int КодБортпроводника { get; set; }

    public string Фамилия { get; set; } = null!;

    public string Имя { get; set; } = null!;

    public string Отчество { get; set; } = null!;

    public int СтажРаботыЧ { get; set; }

    public int КодКомандира { get; set; }

    public int КодПилота { get; set; }

    public int КодПассажира { get; set; }

    public int Attribute1 { get; set; }

    public virtual Пассажир КодПассажираNavigation { get; set; } = null!;

    public virtual Экипаж Экипаж { get; set; } = null!;
}
