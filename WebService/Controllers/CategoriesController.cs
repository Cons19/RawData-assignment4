using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Linq;
using Assignment4.Domain;

namespace Assignment4
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : Controller
    {

        IDataService _dataService;
        LinkGenerator _linkGenerator;

        public CategoriesController(IDataService dataService, LinkGenerator linkGenerator)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _dataService.GetCategories();

            return Ok(categories.Select(x => GetCategoryViewModel(x)));
        }

        // api/categories/id
        [HttpGet("{id}", Name = nameof(GetCategory))]
        public IActionResult GetCategory(int id)
        {
            var category = _dataService.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateUpdateCategoryViewModel model)
        {
            var category = new Category
            {
                Name = model.Name,
                Description = model.Description
            };

            var newCategory =_dataService.CreateCategory(category.Name, category.Description);

            return Created("", newCategory);

        }

        [HttpPut("{id}", Name = nameof(UpdateCategory))]
        public IActionResult UpdateCategory(int id, CreateUpdateCategoryViewModel model)
        {
            var category = _dataService.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            var updatedCategory = new Category
            {
                Id = id,
                Name = model.Name,
                Description = model.Description
            };

            _dataService.UpdateCategory(id, updatedCategory.Name, updatedCategory.Description);

            return Ok(updatedCategory);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _dataService.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            _dataService.DeleteCategory(id);

            return Ok(category);
        }

        private CategoryViewModel GetCategoryViewModel(Category category)
        {
            return new CategoryViewModel
            {
                Url = _linkGenerator.GetUriByName(HttpContext, nameof(GetCategory), new { category.Id }),
                Name = category.Name,
                Desc = category.Description
            };
        }
    }
}