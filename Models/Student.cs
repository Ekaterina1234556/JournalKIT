using System;
using System.Collections.Generic;
using JournalKIT.Models;

namespace JournalKIT;

public partial class Student
{
    public int Id { get; set; }

    public string Namestudent { get; set; } = null!;

    public DateOnly? Birthdate { get; set; }

    public int? Groupid { get; set; }

    public virtual ICollection<Bonusstudent> Bonusstudents { get; set; } = new List<Bonusstudent>();

    public virtual Groupstudent? Group { get; set; }

    public virtual ICollection<Journalofduty> JournalofdutyStudent1s { get; set; } = new List<Journalofduty>();

    public virtual ICollection<Journalofduty> JournalofdutyStudent2s { get; set; } = new List<Journalofduty>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}
