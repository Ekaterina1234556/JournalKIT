using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JournalKIT.Models;

namespace JournalKIT;

public partial class Schedule
{
    public int Id { get; set; }
    [Display(Name = "Группа")]
    public int? Groupstudentid { get; set; }
    [Display(Name = "Дата")]
    public string? Datelessons { get; set; }
    [Display(Name = "Время")]
    public int? Timelessonsid { get; set; }
    [Display(Name = "преподователь")]
    public int? Tutorid { get; set; }
    [Display(Name = "Пара")]
    public int? Lessonsid { get; set; }
    [Display(Name = "ГРуппа")]
    public virtual Groupstudent? Groupstudent { get; set; }
    [Display(Name = "Пара")]
    public virtual Lesson? Lessons { get; set; }
    [Display(Name = "Время")]
    public virtual Timelesson? Timelessons { get; set; }
    [Display(Name = "Преподователь")]
    public virtual Tutor? Tutor { get; set; }
}
