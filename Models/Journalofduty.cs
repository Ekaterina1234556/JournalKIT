using System;
using System.Collections.Generic;

namespace JournalKIT.Models;

public partial class Journalofduty
{
    public int Id { get; set; }

    public DateOnly Dateduty { get; set; }

    public int? Groupstudentid { get; set; }

    public int? Student1id { get; set; }

    public int? Student2id { get; set; }

    public virtual Groupstudent? Groupstudent { get; set; }

    public virtual Student? Student1 { get; set; }

    public virtual Student? Student2 { get; set; }
}
