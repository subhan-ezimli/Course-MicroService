using FreeCourse.Servies.Catalog.Dtos;
using FreeCourse.Servies.Catalog.Model;
using FreeCourse.Shared.Dtos;

namespace FreeCourse.Servies.Catalog.Services
{
    internal interface ICourseService
    {
        Task<Response<List<CourseDto>>> GetAllAsync();
        Task<Response<CourseDto>> CreateAsync(Course course);
        Task<Response<CourseDto>> GetByIdAsync(string id);
        Task<Response<List<CourseDto>>> GetAllByUserId(string userId);
        Task<Response<CourseDto>> CreateAsync(CourseCreateDto courseCreateDto);
        Task<Response<NoContent>> UpdateAsync(CourseUpdateDto courseUpdateDto);
        Task<Response<NoContent>> DeleteAsync(string id);

    }
}
