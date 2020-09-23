using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Product.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductController : ControllerBase
    {
        private static readonly string[] ProductNames = new[]
        {
            "Araba", "Motorsiklet", "Bisiklet", "Çanta", "Ayakkabı", "Telefon", "Saat", "Kulaklık", "Televizyon", "Detarjan"
        };

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Product
            {
                Amount = rng.Next(10, 500),
                AppUrl = HttpContext.Request.Host.ToString(),
                Name = ProductNames[rng.Next(ProductNames.Length)]
            })
            .ToArray();
        }
    }
}
