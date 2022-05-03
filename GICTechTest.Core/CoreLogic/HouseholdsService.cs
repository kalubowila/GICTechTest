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
    public class HouseholdsService : IHouseholdsService
    {
        private readonly IHouseholdsDataService _householdsService;

        public HouseholdsService()
        {
            _householdsService = new HouseholdsDataService();
        }

        public List<HouseholdsModel> GetHouseholdsByStateIDs(string state)
        {
            try
            {
                int[] states = state.Split(",").Select(x => int.Parse(x)).ToArray<int>();

                return _householdsService.GetHouseholdsByStateIDs(states);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw;
            }
        }
    }
}
