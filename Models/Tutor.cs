using System;
using System.Collections.Generic;
using JournalKIT.Models;

namespace JournalKIT;

public partial class Tutor
{
    public int Id { get; set; }

    public string Nametutor { get; set; } = null!;

    public virtual ICollection<Club> Clubs { get; set; } = new List<Club>();

    public virtual ICollection<Groupstudent> Groupstudents { get; set; } = new List<Groupstudent>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
