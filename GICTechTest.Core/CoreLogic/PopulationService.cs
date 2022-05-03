using GICTechTest.Core.ICoreLogic;
using GICTechTest.DataAccess.DataService;
using GICTechTest.DataAccess.IDataService;
using GICTechTest.Model.CustomModels;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GICTechTest.Core.CoreLogic
{
    public class PopulationService : IPopulationService
    {
        private readonly IPopulationDataService _populationDataService;
        public PopulationService()
        {
            _populationDataService = new PopulationDataService();
        }
        public List<PopulationModel> GetPopulationByStateIDs(string state)
        {
            try
            {
                int[] states = state.Split(",").Select(x => int.Parse(x)).ToArray<int>();

                return _populationDataService.GetPopulationByStateIDs(states);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw;
            }
        }
    }
}
