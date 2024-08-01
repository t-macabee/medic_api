using Medic.API.Extensions;
using Medic.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandler>();

app.UseCors(builder => builder
    .AllowAnyHeader()
    .AllowAnyMethod()
    .WithOrigins("https://localhost:4200")
);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
