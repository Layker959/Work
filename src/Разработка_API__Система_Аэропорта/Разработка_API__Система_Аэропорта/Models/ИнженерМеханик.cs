﻿using System;
using System.Collections.Generic;

namespace Разработка_API__Система_Аэропорта.Models;

public partial class ИнженерМеханик
{
    public int КодИнженерМеханика { get; set; }

    public string Фамилия { get; set; } = null!;

    public string Имя { get; set; } = null!;

    public string Отчество { get; set; } = null!;

    public int СтажРаботыЧ { get; set; }

    public int? КодРаботника { get; set; }

    public virtual РаботникАэропорта? КодРаботникаNavigation { get; set; }

    public virtual ICollection<Самолёт> Самолётs { get; set; } = new List<Самолёт>();
}
