using FreeCourse.Servies.Catalog.Dtos;
using FreeCourse.Servies.Catalog.Model;
using FreeCourse.Shared.Dtos;

namespace FreeCourse.Servies.Catalog.Services
{
    internal interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();

        Task<Response<CategoryDto>> CreateAsync(Category category);

        Task<Response<CategoryDto>> GetByIdAsync(string id);

    }
}
