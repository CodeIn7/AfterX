using AfterX;
using AfterX.Contracts.V1;
using AfterX_backend.Contracts.V1.Requests;
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
    public class OrdersController : Controller
    {
        private IOrderService _orderService;
        private readonly UserManager<User> _userManager;
        public OrdersController(IOrderService orderService, UserManager<User> userManager)
        {
            _userManager = userManager;
            _orderService = orderService;
        }

        [HttpGet(ApiRoutes.Orders.GetAll)]
        public async Task<IActionResult> Index()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            // if(!currentUser.IsInRole("BARTENDER")) return Forbid();

            User user = await _userManager.FindByNameAsync(currentUserName);


            return Ok(await _orderService.GetOrdersAsync(user));
        }

        [HttpGet(ApiRoutes.Orders.Get)]
        public async Task<IActionResult> Details([FromRoute] int ordersId)
        {
            var order = await _orderService.GetOrderByIdAsync(ordersId);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpGet(ApiRoutes.Orders.GetByReservationId)]
        public async Task<IActionResult> GetByReservationId([FromRoute] int reservationId)
        {
            var order = await _orderService.GetOrdersByReservationIdAsync(reservationId);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost(ApiRoutes.Orders.Create)]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] PostOrderRequest request)
        {

            var order = new Order
            {
                Active = true,
                Note = request.Note,
                Reservationid = request.Reservationid,
                //Tableid = request.Tableid,
                Time = request.Time.TimeOfDay,
            };

            // await _orderService.CreateOrderAsync(order);

            List<OrderDrink> orderDrinks = new List<OrderDrink>();

            foreach (var drink in request.drinks)
            {
                var orderDrink = new OrderDrink
                {
                    Drinkid = drink.Drinkid,
                    Nobottles = drink.Nobottles,
                    // Orderid = order.Id,
                };
                orderDrinks.Add(orderDrink);
            };
            //await _orderDrinkService.CreateOrdersAsync(orderDrinks);

            var created= await _orderService.CreateOrderAsync(order, orderDrinks);

            if (!created)
            {
                return NoContent();
            }

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Orders.Get.Replace("{orderId}", order.Id.ToString());

            var response = new PostOrderResponse
            {
                Id=order.Id,
                Note=order.Note,
                Active = order.Active,
                Tableid= order.Tableid,
                Time= order.Time
            };

            return Created(locationUri, response);
        }

        [HttpPost(ApiRoutes.Orders.Done)]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromRoute] int orderId)
        {

            await _orderService.DeactivateOrderAsync(orderId);


            return Ok();
        }

        //[HttpPut(ApiRoutes.Orders.Update)]
        ////[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Update([FromRoute] int orderId, [FromBody] UpdateOrderRequest request)
        //{
        //    var order = new Order { Id = orderId, Name = request.Name, NormalizedName = request.Name.ToUpper() };

        //    var updated = await _orderService.UpdateOrderAsync(order);

        //    if (!updated)
        //        return NotFound();

        //    var response = new PostOrderResponse
        //    {
        //        Id = order.Id,
        //        Name = order.Name
        //    };
        //    return Ok(response);
        //}

        [HttpDelete(ApiRoutes.Orders.Delete)]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed([FromRoute] int ordersId)
        {
            var deleted = await _orderService.DeleteOrderAsync(ordersId);

            if (!deleted)
                return NotFound();

            return NoContent();

        }
    }
}
