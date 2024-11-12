using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JournalKIT.Models;

public partial class Lesson
{
    public int Id { get; set; }
    [Display(Name = "Название")]
    public string Namelessons { get; set; } = null!;

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
