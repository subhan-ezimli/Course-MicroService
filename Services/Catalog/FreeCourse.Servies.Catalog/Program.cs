using FreeCourse.Servies.Catalog.Mapping;
using FreeCourse.Servies.Catalog.Services;
using FreeCourse.Servies.Catalog.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
{
    x.Authority = builder.Configuration["IdentityServerUrl"];
    x.Audience = "resource_catalog";
    x.RequireHttpsMetadata = false;
}
    );
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<ICourseService,CourseService>();
builder.Services.AddAutoMapper(typeof(GeneralMapping));
builder.Services.AddControllers(x =>
{
    x.Filters.Add(new AuthorizeFilter());
});
builder.Services.AddControllers();

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddSingleton<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers(); 

app.Run();
