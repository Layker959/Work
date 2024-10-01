using System;
using System.Collections.Generic;

namespace Разработка_API__Система_Аэропорта.Models;

public partial class ТалонБагажа
{
    public string Фамилия { get; set; } = null!;

    public double ВесБагажаКг { get; set; }

    public string МестоПрилёта { get; set; } = null!;

    public int НомерРейса { get; set; }

    public int НомерМеста { get; set; }

    public int КодТалонаБагажа { get; set; }

    public int КодПассажира { get; set; }

    public virtual ICollection<Багаж> Багажs { get; set; } = new List<Багаж>();

    public virtual Пассажир КодПассажираNavigation { get; set; } = null!;

    public virtual ICollection<РучнаяКладь> РучнаяКладьs { get; set; } = new List<РучнаяКладь>();
}
