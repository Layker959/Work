using System;
using System.Collections.Generic;

namespace Разработка_API__Система_Аэропорта.Models;

public partial class Билет
{
    public DateOnly ДатаВылета { get; set; }

    public TimeOnly ВремяВылета { get; set; }

    public int НомерМеста { get; set; }

    public int НомерРяда { get; set; }

    public int НомерРейса { get; set; }

    public string Тариф { get; set; } = null!;

    public TimeOnly ВрмеяВПути { get; set; }

    public DateOnly ДатаПрилёта { get; set; }

    public TimeOnly ВремяПрилёта { get; set; }

    public string Фамилия { get; set; } = null!;

    public string Имя { get; set; } = null!;

    public int КолВоБагажа { get; set; }

    public TimeOnly ВремяОкончанияПосадки { get; set; }

    public string МестоОтправления { get; set; } = null!;

    public string МестоПрилёта { get; set; } = null!;

    public string НазваниеАвиокомпании { get; set; } = null!;

    public int КодБилета { get; set; }

    public int КодПассажира { get; set; }

    public int КодОхранника { get; set; }

    public int КодПограничника { get; set; }

    public virtual Охрана КодОхранникаNavigation { get; set; } = null!;

    public virtual Пассажир КодПассажираNavigation { get; set; } = null!;

    public virtual Пограничник КодПограничникаNavigation { get; set; } = null!;
}
