﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace WSEA.Data.WSEA;

public partial class Realtors
{
    public int IdRealtor { get; set; }

    public string Surname { get; set; }

    public string Name { get; set; }

    public string Patronymic { get; set; }

    public string Phone { get; set; }

    public string AspNetUserId { get; set; }

    public virtual ICollection<Realties> Realties { get; set; } = new List<Realties>();

    public virtual ICollection<Requests> Requests { get; set; } = new List<Requests>();
}