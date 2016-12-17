using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GradProjectWeb.Models
{
    public class PocViewModel
    {
        public TestMode TestMode { get; set; }
        public bool MakeCustomersAroundOneBranch { get; set; }
        public int NumberOfCustomers { get; set; }
        public int NumberOfBranches { get; set; }
        public MinMaxViewModel NumberOfVehiclesPerBranch { get; set; }
        public MinMaxViewModel CapacityOfEachVehicle { get; set; }
        public MinMaxViewModel NumberOfStaffPerBranch { get; set; }
        public MinMaxViewModel StockLevelsPerBranch { get; set; }
        public MinMaxViewModel MaxJourneyDestinationTime { get; set; }
    }

    public class MinMaxViewModel
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }
    public enum TestMode
    {
        RandomData=1,HardCoded=2
    }
}