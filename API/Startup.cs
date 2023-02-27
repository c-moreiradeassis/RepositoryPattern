using Application.Services;
using Application.ServicesIntefaces;
using CrossCutting.ConnectionString;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Repository.Dapper;
using Repository.Database;
using Repository.Database.Context;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            string connectionString = Configuration.GetConnectionString(ConnectionString.Value);

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Example Repository",
                    Description = "API for example",
                    Version = "v1.0.0"
                });
            });

            services.AddScoped<ProductService, ProductServiceImp>();
            services.AddScoped<ProductRepository, ProductRepositoryImp>();

            services.AddScoped<DapperRepository>(d => new DapperRepositoryImp(connectionString));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //---------------------------- SWAGGER ----------------------------
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Example_Repository - v1.0.0");
                // Serve the Swagger UI at the app's root
                c.RoutePrefix = string.Empty;
            });
            //-----------------------------------------------------------------
        }
    }
}
