using System;
using System.Collections.Generic;

namespace JournalKIT;

public partial class Rating
{
    public int Id { get; set; }

    public int? Studentid { get; set; }

    public int? Sportrating { get; set; }

    public int? Sciencerating { get; set; }

    public int? Societyrating { get; set; }

    public virtual Student? Student { get; set; }
}
