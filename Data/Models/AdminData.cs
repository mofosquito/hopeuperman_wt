﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class AdminData
    {
        public AdminData()
        {
            MapMarkers = new HashSet<MapMarkers>();
        }

        public int AdminId { get; set; }
        public string AdminUsername { get; set; }
        public string AdminPassword { get; set; }
        public string AdminEmail { get; set; }

        public virtual ICollection<MapMarkers> MapMarkers { get; set; }
    }
}