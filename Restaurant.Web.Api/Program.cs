using Microsoft.EntityFrameworkCore;

using Restaurant.Infraestructure.Context;
using Restaurant.Infraestructure.Extensions;
using Restaurant.Web.Api.DTOS;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ExtensionsRepository(builder.Configuration);

builder.Services.AddScoped<ApplicationDbContext>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionDefault"),
                m => m.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
