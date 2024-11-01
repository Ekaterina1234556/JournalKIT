using System;
using System.Collections.Generic;

namespace JournalKIT.Models;

public partial class Bonusstudent
{
    public int Id { get; set; }

    public int? Studentid { get; set; }

    public int? Bonusid { get; set; }

    public virtual Bonu? Bonus { get; set; }

    public virtual Student? Student { get; set; }
}
