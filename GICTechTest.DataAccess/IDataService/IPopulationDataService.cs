using System;
using System.Collections.Generic;
using System.Text;
using GICTechTest.Model.CustomModels;

namespace GICTechTest.DataAccess.IDataService
{
    public interface IPopulationDataService
    {
        List<PopulationModel> GetPopulationByStateIDs(int[] states);
    }
}
