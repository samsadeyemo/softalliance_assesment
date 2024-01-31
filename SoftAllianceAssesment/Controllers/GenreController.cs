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
    public class GenreController : Controller
    {
        private readonly IGenre _genre;

        public GenreController(IGenre genre)
        {
            _genre = genre;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll()
        {
            try
            {
                var list = _genre.GetAll();
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
                var details = _genre.GetById(id);
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
        public IActionResult Create([FromBody]CreateGenreRequestModel data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorMessages());
                }
                var model = _genre.Create(data);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("[action]")]
        public IActionResult Update([FromBody]UpdateGenreRequestModel data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorMessages());
                }
                var model = _genre.Update(data);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

       
    }
}
