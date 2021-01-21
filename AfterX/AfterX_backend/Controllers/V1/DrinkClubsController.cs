using AfterX;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_backend.Controllers.V1
{
    public class DrinkClubsController : Controller
    {

        //private IDrinkClubService _drinkClubService;
        //public DrinkClubsController(IDrinkClubService drinkClubService)
        //{
        //    _drinkClubService = drinkClubService;
        //}

        //[HttpGet(ApiRoutes.DrinkClubs.GetAll)]
        //public async Task<IActionResult> Index()
        //{
        //    return Ok(await _drinkClubService.GetDrinkClubsAsync());
        //}

        //[HttpGet(ApiRoutes.DrinkClubs.Get)]
        //public async Task<IActionResult> Details([FromRoute] int drinkClubId)
        //{

        //    var drinkClub = await _drinkClubService.GetDrinkClubByIdAsync(drinkClubId);
        //    if (drinkClub == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(drinkClub);
        //}

        //[HttpPost(AfterX.Contracts.V1.ApiRoutes.DrinkClubs.Create)]
        ////[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([FromBody] PostDrinkClubRequest request)
        //{
        //    var drinkClub = new DrinkClub { Name = request.Name };

        //    var created = await _drinkClubService.CreateDrinkClubAsync(drinkClub);

        //    if (!created)
        //    {
        //        return NoContent();
        //    }

        //    var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
        //    var locationUri = baseUrl + "/" + ApiRoutes.DrinkClubs.Get.Replace("{drinkClubId}", drinkClub.Id.ToString());

        //    var response = new PostDrinkClubResponse
        //    {
        //        Id = drinkClub.Id,
        //        Name = drinkClub.Name
        //    };

        //    return Created(locationUri, response);
        //}

        //[HttpPut(ApiRoutes.DrinkClubs.Update)]
        ////[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Update([FromRoute] int drinkClubId, [FromBody] UpdateDrinkClubRequest request)
        //{
        //    var drinkClub = new DrinkClub { Id = drinkClubId, Name = request.Name, NormalizedName = request.Name.ToUpper() };

        //    var updated = await _drinkClubService.UpdateDrinkClubAsync(drinkClub);

        //    if (!updated)
        //        return NotFound();

        //    var response = new PostDrinkClubResponse
        //    {
        //        Id = drinkClub.Id,
        //        Name = drinkClub.Name
        //    };
        //    return Ok(response);
        //}

        //[HttpDelete(ApiRoutes.DrinkClubs.Delete)]
        ////[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed([FromRoute] int drinkClubId)
        //{
        //    var deleted = await _drinkClubService.DeleteDrinkClubAsync(drinkClubId);

        //    if (!deleted)
        //        return NotFound();

        //    return NoContent();

        //}
    }
}
