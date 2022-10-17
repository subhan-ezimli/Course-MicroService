using AutoMapper;
using FreeCourse.Servies.Catalog.Dtos;
using FreeCourse.Servies.Catalog.Model;
using FreeCourse.Servies.Catalog.Settings;
using FreeCourse.Shared.Dtos;
using MongoDB.Driver;

namespace FreeCourse.Servies.Catalog.Services
{
    internal class CourseService:ICourseService
    {
        private readonly IMongoCollection<Category> _categoryCollection;

        private readonly IMongoCollection<Course> _courseCollection;
        private readonly IMapper _mapper;

        public CourseService(IMongoCollection<Course> courseyCollection, IMapper mapper, IDatabaseSettings databaseSettings, IMongoCollection<Category> categoryCollection)
        {

            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _courseCollection = database.GetCollection<Course>(databaseSettings.CourseCollectionName);
            _mapper = mapper;
            _categoryCollection = categoryCollection;
        }

        public async Task<Response<List<CourseDto>>> GetAllAsync()
        {
            var courses = await _courseCollection.Find(course => true).ToListAsync();

            if (courses.Any())
            {
                foreach (var course in courses)
                {
                    course.Category = await _categoryCollection.Find<Category>(x => x.Id == course.CategoryId).FirstOrDefaultAsync();
                }
            }

            else
            {
                courses = new List<Course>();
            }
            return Response<List<CourseDto>>.Success(_mapper.Map<List<CourseDto>>(courses), 200);
        }

        public async Task<Response<CourseDto>> CreateAsync(Course course)
        {
            await _courseCollection.InsertOneAsync(course);
            return Response<CourseDto>.Success(_mapper.Map<CourseDto>(course), 200);
        }

        public async Task<Response<CourseDto>> GetByIdAsync(string id)
        {
            var course = await _courseCollection.Find<Course>(x => x.Id == id).FirstOrDefaultAsync();
            if (course == null)
            {
                return Response<CourseDto>.Fail("CourseNotFound", 404);
            }
            course.Category = await _categoryCollection.Find<Category>(x => x.Id == course.CategoryId).FirstOrDefaultAsync();

            return Response<CourseDto>.Success(_mapper.Map<CourseDto>(course), 200);
        }

        public async Task<Response<List<CourseDto>>> GetAllByUserId(string userId)
        {
            var courses = await _courseCollection.Find<Course>(x => x.UserId == userId).ToListAsync();

            if (courses.Any())
            {
                foreach (var course in courses)
                {
                    course.Category = await _categoryCollection.Find<Category>(x => x.Id == course.CategoryId).FirstOrDefaultAsync();
                }
            }

            else
            {
                courses = new List<Course>();
            }
            return Response<List<CourseDto>>.Success(_mapper.Map<List<CourseDto>>(courses), 200);
        }

        public async Task<Response<CourseDto>> CreateAsync(CourseCreateDto courseCreateDto)
        {

            var newCourse = _mapper.Map<Course>(courseCreateDto);
            newCourse.CreatedTime = DateTime.Now;
            return Response<CourseDto>.Success(_mapper.Map<CourseDto>(newCourse), 200);
        }
        public async Task<Response<NoContent>> UpdateAsync(CourseUpdateDto courseUpdateDto)
        {
            var updateCourse = _mapper.Map<Course>(courseUpdateDto);

            var result = await _courseCollection.FindOneAndReplaceAsync(x => x.Id == courseUpdateDto.Id, updateCourse);

            if (result == null)
            {
                return Response<NoContent>.Fail("CourseNorFound", 404);
            }
            return Response<NoContent>.Success(204);
        }


        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _courseCollection.DeleteOneAsync(x => x.Id == id);
            if (result.DeletedCount>0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("courseNotFound", 404);
            }

        }
    }
}