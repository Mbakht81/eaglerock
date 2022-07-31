using Microsoft.EntityFrameworkCore;
using EagleRock.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//Added by Maryam
builder.Services.AddSqlite<TrafficDataContext>("Data Source=TrafficData.db");
builder.Services.AddSqlite<LatestDataContext>("Data Source=TrafficData.db");




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    //commented by Maryam
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


//Maryam
//app.MapGet("/TrafficDataList", async (TrafficDataContext db) => await db.TrafficDataList.ToListAsync());
//app.MapGet("/LatestTrafficData", async (LatestDataContext db) => await db.LatestTrafficData.ToListAsync());

app.Run();

