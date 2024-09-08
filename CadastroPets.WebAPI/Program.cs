using CadastroPets.Application.Commands.Handlers;
using CadastroPets.Application.Interfaces;
using CadastroPets.Application.Services;
using CadastroPets.Infrastructure.Data;
using CadastroPets.Infrastructure.Interfaces;
using CadastroPets.Infrastructure.Repositories;
using CadastroPets.WebAPI.Configurations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Register services
builder.Services.AddScoped<IUserService, UserService>();

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Add MediatR for CQRS
builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssembly(typeof(CreateUserCommandHandler).Assembly));

// Add controllers
builder.Services.AddControllers();

// Add Swagger/OpenAPI for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
