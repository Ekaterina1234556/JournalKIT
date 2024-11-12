using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JournalKIT.Models;

namespace JournalKIT;

public partial class Teg
{
    public int Id { get; set; }

    public int? Activityid { get; set; }
    [Display(Name = "Название")]
    public string Nameteg { get; set; } = null!;
   
    public virtual Activity? Activity { get; set; }
}
