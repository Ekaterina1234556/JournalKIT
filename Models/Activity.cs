using System;
using System.Collections.Generic;

namespace JournalKIT.Models;

public partial class Activity
{
    public int Id { get; set; }

    public string Nameactivity { get; set; } = null!;

    public DateOnly? Datecreate { get; set; }

    public string? Property { get; set; }

    public bool? Oneshot { get; set; }

    public int? Creator { get; set; }

    public bool? Crreatoristutor { get; set; }

    public virtual ICollection<Teg> Tegs { get; set; } = new List<Teg>();
}
