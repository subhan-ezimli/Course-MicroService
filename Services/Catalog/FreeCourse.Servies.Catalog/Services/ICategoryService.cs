using FreeCourse.Servies.Catalog.Dtos;
using FreeCourse.Servies.Catalog.Model;
using FreeCourse.Shared.Dtos;

namespace FreeCourse.Servies.Catalog.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();

        Task<Response<CategoryDto>> CreateAsync(CategoryCreateDto categoryDto);

        Task<Response<CategoryDto>> GetByIdAsync(string id);

    }
}
