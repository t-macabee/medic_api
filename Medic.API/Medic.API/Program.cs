using Medic.API.Data;
using Medic.API.Helpers;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Medic.API.Interfaces;
using Medic.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddMapster();
MapsterConfiguration.RegisterMappings();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
