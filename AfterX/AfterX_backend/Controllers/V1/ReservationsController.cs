using AfterX;
using AfterX.Contracts.V1;
using AfterX_backend.Contracts.V1.Requests;
using AfterX_backend.Contracts.V1.Responses;
using AfterX_backend.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AfterX_backend.Controllers.V1
{
    public class ReservationsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private IReservationService _reservationService;
        private IOrderService _orderService;
        private IOrderDrinkService _orderDrinkService;

        public ReservationsController(IReservationService reservationService, UserManager<User> userManager, IOrderDrinkService orderDrinkService, IOrderService orderService)
        {
            _userManager = userManager;
            _orderDrinkService = orderDrinkService;
            _reservationService = reservationService;
            _orderService = orderService;
        }

        [HttpGet(ApiRoutes.Reservations.GetAll)]
        public async Task<IActionResult> Index()
        {
            return Ok(await _reservationService.GetReservationsAsync());
        }

        [HttpGet(ApiRoutes.Reservations.Get)]
        public async Task<IActionResult> Details([FromRoute] int reservationId)
        {

            var reservation = await _reservationService.GetReservationByIdAsync(reservationId);
            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        [HttpPost(ApiRoutes.Reservations.Create)]
        public async Task<IActionResult> Create([FromBody] PostReservationRequest request)
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            User user = await _userManager.FindByNameAsync(currentUserName);
            if(user ==null) return Unauthorized();

            var reservation = new Reservation {
                Numberofpeople=request.Numberofpeople,
                Tableid = request.Tableid,
                Reservationdate = request.Reservationdate,
                Userid = user.Id
            };

            await _reservationService.CreateReservationAsync(reservation);

            foreach(var orderRequest in request.Orders)
            {
                var order = new Order
                {
                    Active = true,
                    Note = orderRequest.Note,
                    Reservationid = reservation.Id,
                    Tableid = request.Tableid,
                    Time = orderRequest.Time.TimeOfDay,
                };

                await _orderService.CreateOrderAsync(order);

                List<OrderDrink> orderDrinks = new List<OrderDrink>();

                foreach (var drink in orderRequest.drinks)
                {
                    var orderDrink = new OrderDrink
                    {
                        Drinkid = drink.Drinkid,
                        Nobottles = drink.Nobottles,
                        Orderid = order.Id,
                    };
                    orderDrinks.Add(orderDrink);
                };
               await _orderDrinkService.CreateOrdersAsync(orderDrinks);


            };


            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Reservations.Get.Replace("{reservationId}", reservation.Id.ToString());

            var response = new PostReservationResponse
            {
            };

            return Created(locationUri, response);
        }

        //[HttpPut(ApiRoutes.Reservations.Update)]
        ////[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Update([FromRoute] int reservationId, [FromBody] UpdateReservationRequest request)
        //{
        //    var reservation = new Reservation { Id = reservationId, Name = request.Name, NormalizedName = request.Name.ToUpper() };

        //    var updated = await _reservationService.UpdateReservationAsync(reservation);

        //    if (!updated)
        //        return NotFound();

        //    var response = new PostReservationResponse
        //    {
        //        Id = reservation.Id,
        //        Name = reservation.Name
        //    };
        //    return Ok(response);
        //}

        [HttpDelete(ApiRoutes.Reservations.Delete)]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed([FromRoute] int reservationId)
        {
            var deleted = await _reservationService.DeleteReservationAsync(reservationId);

            if (!deleted)
                return NotFound();

            return NoContent();

        }
    }
}
