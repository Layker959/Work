using System;
using System.Collections.Generic;

namespace Разработка_API__Система_Аэропорта.Models;

public partial class Самолёт
{
    public string НазваниеАвикомпании { get; set; } = null!;

    public int КолВоМест { get; set; }

    public string МодельСамолёта { get; set; } = null!;

    public TimeOnly ПродолжительностьПолёта { get; set; }

    public int ГрузоподъёмностьТ { get; set; }

    public int КодСамолёта { get; set; }

    public int КодКомандира { get; set; }

    public int КодПилота { get; set; }

    public int КодИнженерМеханика { get; set; }

    public int Attribute1 { get; set; }

    public virtual ИнженерМеханик КодИнженерМеханикаNavigation { get; set; } = null!;

    public virtual ICollection<Пассажир> Пассажирs { get; set; } = new List<Пассажир>();

    public virtual Рассписание? Рассписание { get; set; }

    public virtual Экипаж Экипаж { get; set; } = null!;
}
