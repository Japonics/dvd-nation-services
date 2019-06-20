using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using game_nation_admin_service.Db;
using game_nation_admin_service.Models;

namespace game_nation_admin_service.Controllers
{
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly Mongo _categoryService;

        public CategoriesController(Mongo catService)
        {
            _categoryService = catService;
        }

        [Route("api/Category")]
        [HttpGet]
        public ActionResult<List<Categories>> Get()
        {
            return _categoryService.GetCategory();
        }

        [Route("api/Category/AddCategory")]
        [HttpPost]
        public ActionResult<Categories> AddCategory([FromBody]Categories cat)
        {
            _categoryService.AddCategory(cat);

            return CreatedAtRoute("GetCategory", new { id = cat.Id }, cat);
        }

        [Route("api/Category/Update/{id}")]
        [HttpPut("{id:length(24)}")]
        public IActionResult AttacheCategory(int id, [FromBody]Categories catIn)
        {
            var cat = _categoryService.GetCategory(id);

            if (cat == null)
            {
                return NotFound();
            }

            _categoryService.AttacheCategory(id, catIn);

            return NoContent();
        }

        [Route("api/Category/DettachCategory/{id}")]
        [HttpDelete("{id:length(24)}")]
        public IActionResult DettachCategory(int id)
        {
            var cat = _categoryService.GetCategory(id);

            if (cat == null)
            {
                return NotFound();
            }

            _categoryService.DettachCategory(cat.Id);

            return NoContent();
        }
    }
}
