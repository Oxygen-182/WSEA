﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace WSEA.Data.WSEA;

public partial class Landplot
{
    public int IdLandplot { get; set; }

    public double SquareArea { get; set; }

    public int IdLandplotType { get; set; }

    public virtual LandplotType IdLandplotTypeNavigation { get; set; }

    public virtual ICollection<Realty> Realties { get; set; } = new List<Realty>();
}