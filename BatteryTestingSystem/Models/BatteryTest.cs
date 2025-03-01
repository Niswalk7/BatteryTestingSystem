using System;
using System.Collections.Generic;

namespace BatteryTestingSystem.Models
{
    public class BatteryTest
    {
        public int Id { get; set; }
        public string BatteryId { get; set; }
        public int OperatorId { get; set; }
        public DateTime TestDate { get; set; }
        public bool PassedTest { get; set; }
        public string Notes { get; set; }
        public List<BatteryTestResult> Results { get; set; }

        public BatteryTest()
        {
            BatteryId = string.Empty;
            Notes = string.Empty;
            TestDate = DateTime.Now;
            Results = new List<BatteryTestResult>();
        }
    }

    public class BatteryTestResult
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public int ParameterId { get; set; }
        public double Value { get; set; }
        public bool IsWithinThreshold { get; set; }
    }
}