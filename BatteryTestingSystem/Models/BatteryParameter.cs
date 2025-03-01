using System;
using System.Collections.Generic;

namespace BatteryTestingSystem.Models
{
    public class BatteryParameter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public double MinThreshold { get; set; }
        public double MaxThreshold { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }

        public BatteryParameter()
        {
            Name = string.Empty;
            Unit = string.Empty;
        }
    }
}