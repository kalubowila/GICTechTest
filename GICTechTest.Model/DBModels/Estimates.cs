using System;
using System.Collections.Generic;

namespace GICTechTest.Model.DBModels
{
    public partial class Estimates
    {
        public int State { get; set; }
        public int Districts { get; set; }
        public double? EstimatesPopulation { get; set; }
        public double? EstimatesHouseholds { get; set; }
    }
}
