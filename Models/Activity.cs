using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JournalKIT.Models;

public partial class Activity
{
    public int Id { get; set; }

    [Display(Name = "Название")]
    public string Nameactivity { get; set; } = null!;

    [Display(Name = "Дата начала")]
    public DateOnly? Datecreate { get; set; }

    [Display(Name = "Описание")]
    public string? Property { get; set; }

    [Display(Name = "Одноразовое")]
    public bool? Oneshot { get; set; }

    [Display(Name = "Создатель")]
    public int? Creator { get; set; }

    public bool? Crreatoristutor { get; set; }

    [Display(Name = "Теги")]
    public virtual ICollection<Teg> Tegs { get; set; } = new List<Teg>();
}
