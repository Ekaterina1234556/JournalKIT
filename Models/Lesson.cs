using System;
using System.Collections.Generic;

namespace JournalKIT.Models;

public partial class Lesson
{
    public int Id { get; set; }

    public string Namelessons { get; set; } = null!;

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
