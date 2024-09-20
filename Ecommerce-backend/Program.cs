// 
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Ecommerce_backend.Data;
using Ecommerce_backend.Models;


var builder = WebApplication.CreateBuilder(args);
// Ensure appsettings.json is loaded
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
 
// Add the DbContext using the connection string
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => {     options.AddPolicy(
"AllowAll"
, policy => { policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }); });
 
var app = builder.Build();


if (app.Environment.IsDevelopment())

{


    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });

}
app.UseCors("AllowAll");
 
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();
 

app.MapControllers();
 
app.Run();

 