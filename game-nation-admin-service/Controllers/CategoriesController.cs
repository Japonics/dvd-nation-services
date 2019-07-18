using System.Collections.Generic;
using game_nation_admin_service.Dto;
using Microsoft.AspNetCore.Mvc;
using game_nation_admin_service.Services;

namespace game_nation_admin_service.Controllers
{
    [ApiController]
    [Route("api/admin/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoriesService _categoriesService;

        public CategoriesController(CategoriesService categoriesService)
        {
            this._categoriesService = categoriesService;
        }

        [Route("")]
        [HttpGet]
        public ActionResult<List<CategoryDto>> GetCategories()
        {
            var categories = this._categoriesService.GetCategories();
            return Ok(categories);
        }

        [Route("")]
        [HttpPost]
        public ActionResult<CategoryDto> AddCategory([FromBody]CategoryDto cat)
        {
            var result = this._categoriesService.AddCategory(cat);
            return Ok(result);
        }

        [Route("{categoryId}")]
        [HttpPut]
        public ActionResult<CategoryDto> UpdateCategory(string categoryId, [FromBody] CategoryDto categoryDto)
        {
            var result = this._categoriesService.UpdateCategory(categoryId, categoryDto);
            return Ok(result);
        }

        [Route("{gameId}/attach/{categoryId}")]
        [HttpPut]
        public IActionResult AttachCategory(string gameId, string categoryId)
        {
            return Ok();
        }

        [Route("{gameId}/detach/{categoryId}")]
        [HttpDelete()]
        public IActionResult DetachCategory(string gameId, string categoryId)
        {
            return Ok();
        }
    }
}
