using AfterX.Contracts.V1;
using AfterX.Contracts.V1.Requests;
using AfterX.Contracts.V1.Responses;
using AfterX.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX.Controllers
{
    public class TestController : Controller
    {
        private ICityService _cityService;
        public TestController(ICityService cityService)
        {
            _cityService = cityService;
        }


        [HttpGet(ApiRoutes.Cities.GetAll)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _cityService.GetCitiesAsync());
        }


        [HttpGet(ApiRoutes.Cities.Get)]
        public async Task<IActionResult> GetAll([FromRoute] int cityId)
        {
            var city = await _cityService.GetCityByIdAsync(cityId);

            if (city == null)
                return NotFound();

            return Ok(city);
        }

        [HttpPut(ApiRoutes.Cities.Update)]
        public async Task<IActionResult> Update([FromRoute] int cityId,[FromBody] UpdateCityRequest request)
        {
            var city = new City { Id = cityId, Name = request.Name };

            var updated = await _cityService. UpdateCityAsync(city);

            if (!updated)
                return NotFound();

            return Ok(city);
        }


        [HttpPost(ApiRoutes.Cities.Create)]
        public async Task<IActionResult> Create([FromBody] PostCityRequest cityRequest)
        {
            var city = new City {Name=cityRequest.Name };
       
            await _cityService.CreateCityAsync(city);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Cities.Get.Replace("{cityId}", city.Id.ToString());

            var response = new PostCityResponse
            {
                Id = city.Id,   
                Name = city.Name
            };

            return Created(locationUri,response);
        }

        [HttpDelete(ApiRoutes.Cities.Delete)]
        public async Task<IActionResult> Delete([FromRoute]int cityId)
        {
            var deleted = await _cityService.DeleteCityAsync(cityId);

            if (!deleted)
                return NotFound();

            return NoContent();
        }

    }
}
