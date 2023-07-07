using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); //services to add the controllers
builder.Services.AddDbContext<DataContext>(opt =>

{

opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));

});


var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapControllers();  //Tells to our request, which API endpoint to go for

app.Run();
