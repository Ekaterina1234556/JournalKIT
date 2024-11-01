using System;
using System.Collections.Generic;

namespace JournalKIT.Models;

public partial class Groupstudent
{
    public int Id { get; set; }

    public string Namegroup { get; set; } = null!;

    public DateOnly? Creategroup { get; set; }

    public int? Tutorid { get; set; }

    public int? Specialtyid { get; set; }

    public virtual ICollection<Journalofduty> Journalofduties { get; set; } = new List<Journalofduty>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual Specialty? Specialty { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual Tutor? Tutor { get; set; }
}
