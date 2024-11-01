using System;
using System.Collections.Generic;
using JournalKIT.Models;

namespace JournalKIT;

public partial class Teg
{
    public int Id { get; set; }

    public int? Activityid { get; set; }

    public string Nameteg { get; set; } = null!;

    public virtual Activity? Activity { get; set; }
}
