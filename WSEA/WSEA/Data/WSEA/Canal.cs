﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace WSEA.Data.WSEA;

public partial class Canal
{
    public int IdCanal { get; set; }

    public string Name { get; set; }

    public virtual ICollection<House> Houses { get; set; } = new List<House>();
}