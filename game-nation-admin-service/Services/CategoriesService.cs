using System.Collections.Generic;
using System.Linq;
using game_nation_admin_service.Dto;
using game_nation_shared.Entities;
using game_nation_shared.Repositories;

namespace game_nation_admin_service.Services
{
    public class CategoriesService
    {

        private readonly CategoriesRepository _categoriesRepository;

        public CategoriesService(CategoriesRepository categoriesRepository)
        {
            this._categoriesRepository = categoriesRepository;
        }

        public CategoryDto GetCategory(string id)
        {
            var category = this._categoriesRepository.GetCategory(id);

            if (category == null) return null;

            return new CategoryDto
            {
                Id = category.Id,
                Description = category.Description,
                Name = category.Name,
                Color = category.Color,
                Icon = category.Icon
            };
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            var categories = this._categoriesRepository.GetCategories();

            return categories.Select(category => new CategoryDto
            {
                Id = category.Id,
                Description = category.Description,
                Name = category.Name,
                Color = category.Color,
                Icon = category.Icon
            });
        }

        public CategoryDto AddCategory(CategoryDto categoryDto)
        {
            var category = new Category
            {
                Name = categoryDto.Name,
                Color = categoryDto.Color,
                Description = categoryDto.Description,
                Icon = categoryDto.Icon
            };

            var result = this._categoriesRepository.StoreCategory(category);

            return new CategoryDto
            {
                Id = result.Id,
                Name = result.Name,
                Color = result.Color,
                Description = result.Description,
                Icon = result.Icon
            };
        }

        public CategoryDto UpdateCategory(string id, CategoryDto categoryDto)
        {
            var category = new Category
            {
                Name = categoryDto.Name,
                Color = categoryDto.Color,
                Description = categoryDto.Description,
                Icon = categoryDto.Icon
            };

            var result = this._categoriesRepository.UpdateCategory(id, category);

            return new CategoryDto
            {
                Id = result.Id,
                Name = result.Name,
                Color = result.Color,
                Description = result.Description,
                Icon = result.Icon
            };
        }
    }
}