using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Extensions;
using AutoMapper;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class OrdersController : BaseApiController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _map;
        public OrdersController(IOrderService orderService, IMapper map)
        {
            _map = map;
            _orderService = orderService;  
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto OrderDto)
        {
            var email = HttpContext.User.RetriveveEmailFromPrincipal();

            var address = _map.Map<AddressDto,Address>(OrderDto.ShipToAddress);

            var order = await _orderService.CreateOrderAsync(email,OrderDto.DeliveryMethodId,OrderDto.BasketId,address);

            if(order == null) return BadRequest(new ApiResponse(400,"Problem create order"));

            return order;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderDto>>> GetOrdersForUser()
        {
            var email = HttpContext.User.RetriveveEmailFromPrincipal();

            var orders = await _orderService.GetOrdersForUserAsync(email);

            return Ok(_map.Map<IReadOnlyList<Order>,IReadOnlyList<OrderToReturnDto>>(orders));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderToReturnDto>> GetOrderByIdForUser(int id)
        {
            var email = HttpContext.User.RetriveveEmailFromPrincipal();

            var order = await _orderService.GetOrderByIdAsync(id,email);

            if(order == null) return NotFound(new ApiResponse(400));

            return _map.Map<Order,OrderToReturnDto>(order);
        }

        [HttpGet("deliveryMethods")]
        public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethods()
        {
            return Ok(await _orderService.GetDeliveryMethodsAsync());
        }
    }
}