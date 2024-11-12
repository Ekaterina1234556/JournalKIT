using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JournalKIT.Models;

public partial class Groupstudent
{
    public int Id { get; set; }
    [Display(Name = "Название")]
    public string Namegroup { get; set; } = null!;
    [Display(Name = "Создание группы")]
    public DateOnly? Creategroup { get; set; }
    [Display(Name = "Куратор")]
    public int? Tutorid { get; set; }
     [Display(Name = "Направление")]
    public int? Specialtyid { get; set; }

    public virtual ICollection<Journalofduty> Journalofduties { get; set; } = new List<Journalofduty>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    [Display(Name = "Направление")]
    public virtual Specialty? Specialty { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    [Display(Name = "Куратор")]
    public virtual Tutor? Tutor { get; set; }
}
