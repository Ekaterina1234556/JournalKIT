using System;
using System.Collections.Generic;

namespace JournalKIT.Models;

public partial class Bonu
{
    public int Id { get; set; }

    public string? Namebonus { get; set; }

    public string? Property { get; set; }

    public virtual ICollection<Bonusstudent> Bonusstudents { get; set; } = new List<Bonusstudent>();
}
