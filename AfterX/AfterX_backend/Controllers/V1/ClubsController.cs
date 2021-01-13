using AfterX;
using AfterX.Contracts.V1;
using AfterX_backend.Contracts.V1.Responses;
using AfterX_backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_backend.Controllers.V1
{
    public class ClubsController : Controller
    {
        private IClubService _clubService;
        private IAddressService _addressService;
        private ITableService _tableService;
        public ClubsController(IClubService clubService, IAddressService addressService, ITableService tableService)
        {
            _clubService = clubService;
            _addressService = addressService;
            _tableService = tableService;
        }


        [HttpGet(ApiRoutes.Clubs.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _clubService.GetClubsAsync());
        }


        [HttpGet(ApiRoutes.Clubs.Get)]
        public async Task<IActionResult> Get([FromRoute] int clubId)
        {
            var club = await _clubService.GetClubByIdAsync(clubId);

            if (club == null)
                return NotFound();

            return Ok(club);
        }

        //[HttpPut(ApiRoutes.Clubs.Update)]
        //public async Task<IActionResult> Update([FromRoute] int clubId, [FromBody] UpdateClubRequest request)
        //{
        //    var club = new Club { Id = clubId, Name = request.Name };

        //    var updated = await _clubService.UpdateClubAsync(club);

        //    if (!updated)
        //        return NotFound();

        //    return Ok(club);
        //}


        [HttpPost(ApiRoutes.Clubs.Create)]
        public async Task<IActionResult> Create([FromBody] PostClubRequest clubRequest)
        {
           
            var club = new Club {
                Name = clubRequest.ClubName 
            };

            var address = await _addressService.GetAddressByFormAsync(clubRequest.Cityid, clubRequest.Street, clubRequest.Number);

            if (address == null)
            {
                address = new Address
                {
                    Cityid = clubRequest.Cityid,
                    Number = clubRequest.Number,
                    Street = clubRequest.Street
                };

                if (!await _addressService.CreateAddressAsync(address))
                {
                    return NotFound();//treba promijeniti u error
                }
            }

            club.Addressid = address.Id;

            var created = await _clubService.CreateClubAsync(club);
            if (!created)
            {
                return NotFound();//treba promijeniti u error
            }

            List<Table> tables = new List<Table>();
            int tableNumber = 1;
            foreach (KeyValuePair<int, TableRequest> entity in clubRequest.Tables)
            {
                var tableTypeId = entity.Key;
                var numberOfTablesToCreate = entity.Value.numberOfTables;
                for (int i = 0; i < numberOfTablesToCreate; i++, tableNumber++)
                {
                    var table = new Table
                    {
                        Number = tableNumber,
                        Tabletypeid = tableTypeId,
                        Clubid = club.Id,
                        Capacity = entity.Value.Capacity,
                        Minnobottles = entity.Value.Minnobottles

                    };
                    tables.Add(table);
                }
            }
            


            
            if (!await _tableService.CreateTablesAsync(tables, true, club.Id))
            {
                return NotFound();//treba promijeniti u error
            }
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Clubs.Get.Replace("{clubId}", club.Id.ToString());

            var response = new PostClubResponse
            {
                ClubId = club.Id,
                Name = club.Name,
                Tables = club.Tables,
                AddressId = address.Id,
                Cityid = address.Cityid,
                Number = address.Number
            };

            return Created(locationUri, response);
        }

        //[HttpDelete(ApiRoutes.Clubs.Delete)]
        //public async Task<IActionResult> Delete([FromRoute] int clubId)
        //{
        //    var deleted = await _clubService.DeleteClubAsync(clubId);

        //    if (!deleted)
        //        return NotFound();

        //    return NoContent();
        //}

    }
}
