using GICTechTest.DataAccess.IDataService;
using GICTechTest.Model.CustomModels;
using GICTechTest.Model.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GICTechTest.DataAccess.DataService
{
    public class PopulationDataService : IPopulationDataService
    {
        public List<PopulationModel> GetPopulationByStateIDs(int[] states)
        {
            using (GICTechTest_Context context = new GICTechTest_Context())
            {
                int[] listForEstimates = states.Where(a => !context.Actuals.Select(b => b.State).ToArray().Contains(a)).ToArray();

                var list = context.Actuals
                    .Where(a => states.Contains(a.State))
                    .Select(a => new PopulationModel {
                        State = a.State,
                        Population = a.ActualPopulation
                    }).Union(
                        context.Estimates
                        .Where(b => listForEstimates.Contains(b.State))
                        .GroupBy(b => b.State)
                        .Select(b => new PopulationModel
                        {
                            State = b.First().State,
                            Population = b.Sum(c => c.EstimatesPopulation)
                        })
                    )
                    .OrderBy(a => a.State)
                    .ToList();

                return list;
            }
            
        }
    }
}
