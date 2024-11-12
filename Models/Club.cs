using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JournalKIT.Models;

public partial class Club
{
    public int Id { get; set; }
    [Display(Name = "Название")]
    public string Nameclub { get; set; } = null!;
    [Display(Name = "Руководитель")]
    public int? Tutorid { get; set; }
    [Display(Name = "Описание")]
    public string? Property { get; set; }
    [Display(Name = "Руководитель")]
    public virtual Tutor? Tutor { get; set; }
}
