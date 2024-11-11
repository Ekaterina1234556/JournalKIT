using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JournalKIT.Models;

public partial class Bonu
{
    public int Id { get; set; }
    [Display(Name = "Название")]
    public string? Namebonus { get; set; }
    [Display(Name = "Описание")]
    public string? Property { get; set; }

    public virtual ICollection<Bonusstudent> Bonusstudents { get; set; } = new List<Bonusstudent>();
}
