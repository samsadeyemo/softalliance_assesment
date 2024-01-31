using Microsoft.AspNetCore.Mvc;
using SoftAllianceAssesment.HelperClass;
using SoftAllianceAssesment.Interface;
using SoftAllianceAssesment.Models.RequestModels;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace SoftAllianceAssesment.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountry _country;

        public CountryController(ICountry country)
        {
            _country = country;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll()
        {
            try
            {
                var list = _country.GetAll();
                if (list == null) return NotFound();
                return Ok(list);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetById([Required] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorMessages());
                }
                var details = _country.GetById(id);
                if (details == null) return NotFound();
                return Ok(details);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Create([FromBody]CreateCountryRequestModel data)
        {
           
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorMessages());
                }
                var model = _country.Create(data);
                return Ok(model);

        }

        [HttpPut]
        [Route("[action]")]
        public IActionResult Update([FromBody]UpdateCountryRequestModel data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorMessages());
                }
                var model = _country.Update(data);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

      
    }
}
