using CadastroPets.Application.Commands.Handlers;
using CadastroPets.Application.Interfaces;
using CadastroPets.Application.Services;
using CadastroPets.Infrastructure.Data;
using CadastroPets.Infrastructure.Interfaces;
using CadastroPets.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CadastroPets.WebAPI.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUserService, UserService>();

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUserCommandHandler).Assembly));

            services.AddControllers();

            // Add Swagger/OpenAPI for API documentation.
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}

