using FreeCourse.Servies.Catalog.Dtos;
using FreeCourse.Servies.Catalog.Services;
using FreeCourse.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace FreeCourse.Servies.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : CustomBaseController
    {
        private ICourseService _courseService;
        public CoursesController (ICourseService courseService)
        {
            _courseService=courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var responce= await _courseService.GetAllAsync();
            return CreateActionResultInstance(responce);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var responce= await _courseService.GetByIdAsync(id);
            return CreateActionResultInstance(responce);

        }

        [HttpGet("GetAllByUserId/{userId}")]
        public async Task<IActionResult> GetAllByUserId(string userId)
        {
            var responce = await _courseService.GetAllByUserId(userId);
            return CreateActionResultInstance(responce);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseCreateDto courseCreateDto)
        {
            var responce=await _courseService.CreateAsync(courseCreateDto);
            return CreateActionResultInstance(responce);

        }

        [HttpPut]
        public async Task<IActionResult> Update(CourseUpdateDto courseUpdateDto)
        {
            var responce = await _courseService.UpdateAsync(courseUpdateDto);
            return CreateActionResultInstance(responce);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var responce = await _courseService.DeleteAsync(id);
            return CreateActionResultInstance(responce);

        }

    }
}
