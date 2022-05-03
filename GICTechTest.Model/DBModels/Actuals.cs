using System;
using System.Collections.Generic;

namespace GICTechTest.Model.DBModels
{
    public partial class Actuals
    {
        public int State { get; set; }
        public double? ActualPopulation { get; set; }
        public double? ActualHouseholds { get; set; }
    }
}
