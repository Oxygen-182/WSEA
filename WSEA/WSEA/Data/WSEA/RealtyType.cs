﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace WSEA.Data.WSEA;

public partial class RealtyType
{
    public int IdType { get; set; }

    public string Type { get; set; }

    public virtual ICollection<Realty> Realties { get; set; } = new List<Realty>();
}