using AfterX;
using AfterX.Contracts.V1;
using AfterX_backend.Contracts.V1.Requests;
using AfterX_backend.Contracts.V1.Responses;
using AfterX_backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_backend.Controllers.V1
{
    public class DrinkTypesController : Controller
    {
        private IDrinkTypesService _drinkTypesService;
        public DrinkTypesController(IDrinkTypesService drinkTypesService)
        {
            _drinkTypesService = drinkTypesService;
        }


        [HttpGet(ApiRoutes.DrinkTypes.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _drinkTypesService.GetDrinkTypesAsync());
        }


        [HttpGet(ApiRoutes.DrinkTypes.Get)]
        public async Task<IActionResult> Get([FromRoute] int drinkTypesId)
        {
            var drinkTypes = await _drinkTypesService.GetDrinkTypeByIdAsync(drinkTypesId);

            if (drinkTypes == null)
                return NotFound();

            return Ok(drinkTypes);
        }

        [HttpPut(ApiRoutes.DrinkTypes.Update)]
        public async Task<IActionResult> Update([FromRoute] int drinkTypesId, [FromBody] UpdateDrinkTypeRequest request)
        {
            var drinkTypes = new DrinkType { Id = drinkTypesId, Name = request.Name };

            var updated = await _drinkTypesService.UpdateDrinkTypeAsync(drinkTypes);

            if (!updated)
                return NotFound();

            return Ok(drinkTypes);
        }


        [HttpPost(ApiRoutes.DrinkTypes.Create)]
        public async Task<IActionResult> Create([FromBody] PostDrinkTypeRequest drinkTypesRequest)
        {
            var drinkTypes = new DrinkType { Name = drinkTypesRequest.Name };

            await _drinkTypesService.CreateDrinkTypeAsync(drinkTypes);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.DrinkTypes.Get.Replace("{drinkTypesId}", drinkTypes.Id.ToString());

            var response = new PostDrinkTypeResponse
            {
                Id = drinkTypes.Id,
                Name = drinkTypes.Name
            };

            return Created(locationUri, response);
        }

        [HttpDelete(ApiRoutes.DrinkTypes.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int drinkTypesId)
        {
            var deleted = await _drinkTypesService.DeleteDrinkTypeAsync(drinkTypesId);

            if (!deleted)
                return NotFound();

            return NoContent();
        }

    }
}
