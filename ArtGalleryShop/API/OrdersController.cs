using System.Collections.Generic;
using ArtGalleryShop.ArtGalleryContext;
using ArtGalleryShop.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ArtGalleryShop.API
{
    [Route("api/[Controller]")]
    public class OrdersController:Controller
    {
        private readonly IArtGalleryContext _artGalleryContext;

        public OrdersController(IArtGalleryContext artGalleryContext)
        {
            _artGalleryContext = artGalleryContext;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _artGalleryContext.GetOrders();
        }

        [HttpGet]
        [Route("{orderId:int}")]
        public IActionResult Get(int orderId)
        {
            var order = _artGalleryContext.GetOrderById(orderId);

            if (order != null) return Ok(order);

            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Order order)
            {
             _artGalleryContext.Add(order);
            var savedSuccessfully = _artGalleryContext.SaveAllChanges();

            if (savedSuccessfully)
            {
                return Created($"api/orders/{order.Id}", order);
            }

            return BadRequest("Failed to add a new Order");
        }
    }
}
