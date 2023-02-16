
using RepairService.Services.Interfaces;
using RepairService.Repositiries.Interfaces;
using RepairService.Models;
using RepairService.Repositiries.Implimentations;
using RepairService.Database;
using Microsoft.EntityFrameworkCore;
using RepairService.Services.Implimentations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(connection));
builder.Services.AddTransient<IRepairService,RepairService.Services.Implimentations.RepairService>();
builder.Services.AddTransient<IWorkerService,WorkerService>();
builder.Services.AddTransient<IBaseRepository<Document>,BaseRepository<Document>>();
builder.Services.AddTransient<IBaseRepository<Car>,BaseRepository<Car>>();
builder.Services.AddTransient<IBaseRepository<Worker>,BaseRepository<Worker>>();

builder.Services.AddMvc();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
