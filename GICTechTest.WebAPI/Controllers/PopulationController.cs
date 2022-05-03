using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GICTechTest.Core.CoreLogic;
using GICTechTest.Core.ICoreLogic;
using GICTechTest.Model.CustomModels;
using GICTechTest.WebAPI.ActionFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace GICTechTest.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopulationController : ControllerBase
    {
        private readonly IPopulationService _populationService;
        public PopulationController()
        {
            _populationService = new PopulationService();
        }

        // GET api/population
        [HttpGet]
        [RequestLogger]
        public ActionResult Get([FromQuery(Name = "state")] string state)
        {
            if (!string.IsNullOrEmpty(state))
            {
                List<PopulationModel> populationList = _populationService.GetPopulationByStateIDs(state);

                if (populationList.Count > 0)
                {
                    return Ok(populationList);
                }
            }
            return NotFound();
        }
    }
}