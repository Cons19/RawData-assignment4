using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Assignment4.Domain;

namespace Assignment4
{
    public class ProductsController
    {
        IDataService _dataService;
        LinkGenerator _linkGenerator;

        public ProductsController(IDataService dataService, LinkGenerator linkGenerator)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("{id}", Name = nameof(GetProduct))]
        public IActionResult GetProduct(int id)
        {
            var product = _dataService.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}
