using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JournalKIT.Models;

namespace JournalKIT;

public partial class Student
{
    public int Id { get; set; }
    [Display(Name = "ФИО")]
    public string Namestudent { get; set; } = null!;
    [Display(Name = "Дата рождения")]
    public DateOnly? Birthdate { get; set; }
    [Display(Name = "Группа")]
    public int? Groupid { get; set; }

    public virtual ICollection<Bonusstudent> Bonusstudents { get; set; } = new List<Bonusstudent>();
    [Display(Name = "Группа")]
    public virtual Groupstudent? Group { get; set; }

    public virtual ICollection<Journalofduty> JournalofdutyStudent1s { get; set; } = new List<Journalofduty>();

    public virtual ICollection<Journalofduty> JournalofdutyStudent2s { get; set; } = new List<Journalofduty>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}
