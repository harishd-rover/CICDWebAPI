using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TaskManageAPI.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TaskManageAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TaskManageAPIContext")));
// Add services to the container.

builder.Services.AddControllers();

//Enabling Cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
        });
});
//tttttt


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Enabling Swagger Summarirising
builder.Services.AddSwaggerGen();
//hjjjgjgjgjgj

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

//Enabling Cors
app.UseCors();

app.Run();
