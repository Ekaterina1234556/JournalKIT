using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JournalKIT.Models;

namespace JournalKIT;

public partial class Specialty
{
    public int Id { get; set; }
    [Display(Name = "Название")]
    public string Namespecialty { get; set; } = null!;

    public virtual ICollection<Groupstudent> Groupstudents { get; set; } = new List<Groupstudent>();
}
