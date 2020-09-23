using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Order.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class OrderController : ControllerBase
    {
        private static readonly string[] ProductNames = new[]
        {
            "Araba", "Motorsiklet", "Bisiklet", "Çanta", "Ayakkabı", "Telefon", "Saat", "Kulaklık", "Televizyon", "Detarjan"
        };

        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index =>  new Order
            {
                OrderedDate = DateTime.Now.AddDays(index),
                TotalAmount = rng.Next(10, 500),
                AppUrl = HttpContext.Request.Host.ToString(),
                ProductName = ProductNames[rng.Next(ProductNames.Length)]
            })
            .ToArray();
        }
    }
}
