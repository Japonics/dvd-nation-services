using System.Collections.Generic;
using game_nation_admin_service.Dto;
using Microsoft.AspNetCore.Mvc;
using game_nation_admin_service.Entities;
using game_nation_admin_service.Repositories;
using game_nation_admin_service.Services;

namespace game_nation_admin_service.Controllers
{
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoriesService _categoriesService;

        public CategoriesController(CategoriesService categoriesService)
        {
            this._categoriesService = categoriesService;
        }

        [Route("api/category")]
        [HttpGet]
        public ActionResult<List<CategoryDto>> Get()
        {
            return this._categoriesRepository.GetCategory();
        }

        [Route("api/category")]
        [HttpPost]
        public ActionResult<CategoryDto> AddCategory([FromBody]CategoryDto cat)
        {
            this._categoriesRepository.AddCategory(cat);

            return CreatedAtRoute("GetCategory", new { id = cat.Id }, cat);
        }

        [Route("api/category/{id}")]
        [HttpPut("{id:length(24)}")]
        public IActionResult AttachCategory(string id, [FromBody]CategoryDto catIn)
        {
            var cat = this._categoriesRepository.GetCategory(id);

            if (cat == null)
            {
                return NotFound();
            }

            this._categoriesRepository.AttachCategory(id, catIn);

            return NoContent();
        }

        [Route("api/category/detach/{id}")]
        [HttpDelete("{id:length(24)}")]
        public IActionResult DetachCategory(int id)
        {
            var cat = this._categoriesRepository.GetCategory(id);

            if (cat == null)
            {
                return NotFound();
            }

            this._categoriesRepository.DetachCategory(cat.Id);

            return NoContent();
        }
    }
}
