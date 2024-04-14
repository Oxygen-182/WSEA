﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace WSEA.Data.WSEA;

public partial class Realty
{
    public int IdRealty { get; set; }

    public string City { get; set; }

    public string District { get; set; }

    public string Street { get; set; }

    public string House { get; set; }

    public string ApartmentNumber { get; set; }

    public double? SquareObject { get; set; }

    public double? SquareArea { get; set; }

    public string Material { get; set; }

    public int? RoomCount { get; set; }

    public string Floor { get; set; }

    public decimal Cost { get; set; }

    public int? YearOfCommissioning { get; set; }

    public bool BuildDone { get; set; }

    public bool Rent { get; set; }

    public string CadastralNumber { get; set; }

    public string Description { get; set; }

    public int RealtyTypeId { get; set; }

    public int? IdRealtor { get; set; }

    public virtual Realtor IdRealtorNavigation { get; set; }

    public virtual ICollection<RealtyImage> RealtyImages { get; set; } = new List<RealtyImage>();

    public virtual RealtyType RealtyType { get; set; }
}