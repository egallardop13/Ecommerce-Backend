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
builder.Services.AddCors(options => {
    options.AddPolicy("DevCors", corsBuilder => {
        corsBuilder.WithOrigins("http://localhost:5053")
                   .AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
    });
    options.AddPolicy("ProdCors", corsBuilder => {
        corsBuilder.WithOrigins("http://ecommerceBackend.azurewebsites.net/")
                   .AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
    });
});
 
var app = builder.Build();
 
if (app.Environment.IsDevelopment())
{
    app.UseCors("DevCors");
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}
else
{
    app.UseCors("ProdCors");
    app.UseHttpsRedirection();
}
 
// app.UseAuthorization();
 
app.UseRouting();
app.MapControllers();
app.Run();

//  "AllowedHosts": "*",
//   "ASPNETCORE_ENVIRONMENT": "Production",
//   "Kestrel": {
//     "Endpoints": {
//       "Http": {
//         "Url": "http://*:5000"
//       },
//       "Https": {
//         "Url": "https://*:5001"
//       }
//     }