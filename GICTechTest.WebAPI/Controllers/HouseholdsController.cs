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

namespace GICTechTest.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseholdsController : ControllerBase
    {
        private readonly IHouseholdsService _householdsService;
        public HouseholdsController()
        {
            _householdsService = new HouseholdsService();
        }
        // GET api/households
        [HttpGet]
        [RequestLogger]
        public ActionResult<string> Get([FromQuery(Name = "state")] string state)
        {
            if (!string.IsNullOrEmpty(state))
            {
                List<HouseholdsModel> populationList = _householdsService.GetHouseholdsByStateIDs(state);

                if (populationList.Count > 0)
                {
                    return Ok(populationList);
                }
            }
            return NotFound();
        }
    }
}