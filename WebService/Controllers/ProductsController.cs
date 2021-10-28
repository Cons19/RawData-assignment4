using Assignment4;
using WebService.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;

namespace Assignment4
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : Controller
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

            product.Category = _dataService.GetCategory(product.CategoryId);

            return Ok(product);
        }

        [HttpGet("category/{id}")]
        public IActionResult GetProductByCategory(int id)
        {
            var products = _dataService.GetProductByCategory(id);
            IList<ProductByCategoryViewModel> productByCategoryViewModelList = new List<ProductByCategoryViewModel>();

            if (products.Count == 0)
            {
                return NotFound(products);
            }

            foreach (Product p in products)
            {
                p.Category = _dataService.GetCategory(id);
                productByCategoryViewModelList.Add(GetProductByCategoryViewModel(p, p.Category.Name));
            }

            return Ok(productByCategoryViewModelList);
        }
        /*
        [HttpGet("name/{substring}")]
        public IActionResult GetProductBySubstring(string substring)
        {
            var products = _dataService.GetProductByName(substring);

            if (products.Count == 0)
            {
                return NotFound(products);
            }
            
            foreach (Product p in products)
            {
                p.Category = _dataService.GetCategory(id);
                productViewModelList.Add(GetProductViewModel(p, p.Category.Name));
            }

            //return Ok(productViewModelList);
        }*/

        private ProductByCategoryViewModel GetProductByCategoryViewModel(Product product, string categoryName)
        {
            return new ProductByCategoryViewModel
            {
                Name = product.Name,
                UnitPrice = product.UnitPrice,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitsInStock = product.UnitsInStock,
                CategoryName = categoryName,
                CategoryId = product.CategoryId
            };
        }

        private ProductBySubstringViewModel GetProductBySubstringViewModel(Product product, string categoryName)
        {
            return new ProductBySubstringViewModel
            {
                ProductName = product.Name,
                UnitPrice = product.UnitPrice,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitsInStock = product.UnitsInStock,
                CategoryName = categoryName,
                CategoryId = product.CategoryId
            };
        }
    }
}
