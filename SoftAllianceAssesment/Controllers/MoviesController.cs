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
    public class MoviesController : Controller
    {
        private readonly IMovie _movie;

        public MoviesController(IMovie movie)
        {
            _movie = movie;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAll()
        {
            try
            {
                var list = _movie.GetAll();
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
                var details = _movie.GetById(id);
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
        public IActionResult Create([FromBody]CreateMovieRequestModel data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorMessages());
                }
                var model = _movie.Create(data);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("[action]")]
        public IActionResult Update([FromBody]UpdateMovieRequestModel data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorMessages());
                }
                var model = _movie.Update(data);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete([Required] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorMessages());
                }
                var model = _movie.Delete(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
