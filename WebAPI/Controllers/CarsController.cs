using Business.Abstract;
using Business.Concrate;
using DataAccess.Concrate.EntityFramework;
using Entity.Concrate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }


        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result=_carService.Delete(car);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var resulut = _carService.Update(car);
            if (resulut.Success)
            {
                return Ok(resulut);
            }
            return BadRequest(resulut.Message);
        }


        [HttpGet("getbydailyprice")]
        public IActionResult GetByDailyPrice(int min, int max)
        {
            var result =_carService.GetByDailyPrice(min, max);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
           var result=_carService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    
    }
}
