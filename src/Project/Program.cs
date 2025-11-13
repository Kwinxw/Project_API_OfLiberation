using BusinessLogic.Services;
using DataAccess.Models;
using DataAccess.Wrapper;
using Domain.Interfaces;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    options.JsonSerializerOptions.WriteIndented = true;
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                });

            builder.Services.AddDbContext<SqlContext>(
                option => option.UseSqlServer(
                    "Server=DESKTOP-K6LFJKO;Database=SQL;User Id=sa;Password=12345;TrustServerCertificate=true;"));

            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IStudentsService, StudentsService>();
            builder.Services.AddScoped<ITeachersService, ПреподавателиService>();
            builder.Services.AddScoped<IGroupsService, GroupsService>();
            builder.Services.AddScoped<ILoadService, LoadService>();
            builder.Services.AddScoped<ISpecialtiesService, SpecialtiesService>();
            builder.Services.AddScoped<IQuestsService, QuestsService>();
            builder.Services.AddScoped<ITaskTypesService, TaskTypesService>();
            builder.Services.AddScoped<IReasonsForLiberationService, ReasonsForLiberationService>();
            builder.Services.AddScoped<ILiberationService, LiberationService>();
            builder.Services.AddScoped<IBranchesService, BranchesService>();
            builder.Services.AddScoped<IGradeService, GradeService>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Журнал освобождений студентов API",
                    Description = "API для управления журналом освобождений студентов от занятий физической культурой",
                    Contact = new OpenApiContact
                    {
                        Name = "Администрация учебного заведения",
                        Url = new Uri("https://college.example.com/contact"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Внутренняя лицензия учебного заведения",
                        Url = new Uri("https://college.example.com/api-license")
                    },
                    TermsOfService = new Uri("https://college.example.com/api-terms")
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
