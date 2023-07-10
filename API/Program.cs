using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); //services to add the controllers
builder.Services.AddDbContext<DataContext>(opt =>

{

opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));

});

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

app.MapControllers();  //Tells to our request, which API endpoint to go for

app.Run();
