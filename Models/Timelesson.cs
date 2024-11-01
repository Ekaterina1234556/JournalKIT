using System;
using System.Collections.Generic;

namespace JournalKIT;

public partial class Timelesson
{
    public int Id { get; set; }

    public int? Numberlessons { get; set; }

    public TimeOnly? Startlessons { get; set; }

    public TimeOnly? Endlessons { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
