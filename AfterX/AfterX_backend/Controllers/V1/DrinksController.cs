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
    public class DrinksController : Controller
    {
        private IDrinkService _drinkService;
        public DrinksController(IDrinkService drinkService)
        {
            _drinkService = drinkService;
        }


        [HttpGet(ApiRoutes.Drinks.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _drinkService.GetDrinksAsync());
        }


        [HttpGet(ApiRoutes.Drinks.Get)]
        public async Task<IActionResult> Get([FromRoute] int drinkId)
        {
            var drink = await _drinkService.GetDrinkByIdAsync(drinkId);

            if (drink == null)
                return NotFound();

            return Ok(drink);
        }

        [HttpPut(ApiRoutes.Drinks.Update)]
        public async Task<IActionResult> Update([FromRoute] int drinkId, [FromBody] UpdateDrinkRequest request)
        {
            var drink = new Drink {
                Id = drinkId,
                Name=request.Name, 
                Quantity = request.Quantity, 
                Drinktypeid =request.Drinktypeid 
            };

            var updated = await _drinkService.UpdateDrinkAsync(drink);

            if (!updated)
                return NotFound();

            return Ok(drink);
        }


        [HttpPost(ApiRoutes.Drinks.Create)]
        public async Task<IActionResult> Create([FromBody] PostDrinkRequest drinkRequest)
        {
            var drink = new Drink {
                Name = drinkRequest.Name,
                Quantity = drinkRequest.Quantity,
                Drinktypeid = drinkRequest.Drinktypeid,            
            };

            await _drinkService.CreateDrinkAsync(drink);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Drinks.Get.Replace("{drinkId}", drink.Id.ToString());

            var response = new PostDrinkResponse
            {
                Id = drink.Id,
                Name = drink.Name,
                Quantity = drink.Quantity,
                Drinktypeid = drink.Drinktypeid,
            };

            return Created(locationUri, response);
        }

        [HttpDelete(ApiRoutes.Drinks.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int drinkId)
        {
            var deleted = await _drinkService.DeleteDrinkAsync(drinkId);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
