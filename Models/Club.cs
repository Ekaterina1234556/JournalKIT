using System;
using System.Collections.Generic;

namespace JournalKIT.Models;

public partial class Club
{
    public int Id { get; set; }

    public string Nameclub { get; set; } = null!;

    public int? Tutorid { get; set; }

    public string? Property { get; set; }

    public virtual Tutor? Tutor { get; set; }
}
