using System;
using System.Collections.Generic;
using System.Text;
using GICTechTest.Model.CustomModels;

namespace GICTechTest.Core.ICoreLogic
{
    public interface IHouseholdsService
    {
        List<HouseholdsModel> GetHouseholdsByStateIDs(string state);
    }
}
