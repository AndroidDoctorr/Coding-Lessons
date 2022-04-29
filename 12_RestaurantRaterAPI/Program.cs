using Microsoft.EntityFrameworkCore;
using RestaurantRaterAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//###########Things Added################
//Getting the connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//Passing it to the DbContext
//This will require bringing in Using Statement for EntityFrameworkCore
builder.Services.AddDbContext<RestaurantDbContext>(options => options.UseSqlServer(connectionString));
//we will no move over to building out endpoint functionality
//First however we will want to make an edit model

//Adding ReferenceLoopHandling
//dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson
builder.Services.AddControllers().AddNewtonsoftJson(
    options => options.SerializerSettings.ReferenceLoopHandling =
    Newtonsoft.Json.ReferenceLoopHandling.Ignore
);


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

//Can pass a url here to specify the port being run on. in this case we are using the standard https number of 443
//meaning that we can make queries of our api at https://localhost/ or view swagger at https://localhost/swagger
app.Run("https://localhost:443");
