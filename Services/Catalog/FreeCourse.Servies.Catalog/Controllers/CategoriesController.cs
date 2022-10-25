using FreeCourse.Servies.Catalog.Dtos;
using FreeCourse.Servies.Catalog.Services;
using FreeCourse.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Servies.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController( ICategoryService category)
        {
            _categoryService=category;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var responce = await _categoryService.GetAllAsync();
            return CreateActionResultInstance(responce);
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var responce= await _categoryService.GetByIdAsync(id);
            return CreateActionResultInstance(responce);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto categoryDto)
        {
            var responce = await _categoryService.CreateAsync(categoryDto);
            return CreateActionResultInstance(responce);
        }

    }
}
