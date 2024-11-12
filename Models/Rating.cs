using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JournalKIT;

public partial class Rating
{
    public int Id { get; set; }
    [Display(Name = "Студент")]
    public int? Studentid { get; set; }
    [Display(Name = "Спорт")]
    public int? Sportrating { get; set; }
    [Display(Name = "Наука")]
    public int? Sciencerating { get; set; }
    [Display(Name = "Общество")]
    public int? Societyrating { get; set; }
    [Display(Name = "Студент")]
    public virtual Student? Student { get; set; }
}
