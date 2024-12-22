﻿using MyApiProject.DomainLayer.Shared;

namespace MyApiProject.DomainLayer
{
    public class Personnel : BaseClass
    {
        public string FullName { get; set; }
        public DateTime BirtDate { get; set; }
        public GenderType Gender { get; set; }
        public int DistrictId { get; set; }
        public District District { get; set; }
    }
}