﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace hopeuperman_data.Models
{
    public partial class MapMarkers
    {
        public int MarkerId { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string MainLangauge { get; set; }
        public string Dialect { get; set; }
        public Guid? AudioFile { get; set; }
        public string Tag { get; set; }
    }
}