using System;
using System.Collections.Generic;
using JournalKIT.Models;

namespace JournalKIT;

public partial class Schedule
{
    public int Id { get; set; }

    public int? Groupstudentid { get; set; }

    public string? Datelessons { get; set; }

    public int? Timelessonsid { get; set; }

    public int? Tutorid { get; set; }

    public int? Lessonsid { get; set; }

    public virtual Groupstudent? Groupstudent { get; set; }

    public virtual Lesson? Lessons { get; set; }

    public virtual Timelesson? Timelessons { get; set; }

    public virtual Tutor? Tutor { get; set; }
}
