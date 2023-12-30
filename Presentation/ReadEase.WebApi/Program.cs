using ReadEase.Persistance;
using ReadEase.Application;
using ReadEase.Application.Services;
using ReadEase.Persistance.Services;
using ReadEase.Application.Services.Repositories;
using ReadEase.Persistance.Repositories;
using GenericRepository;
using ReadEase.Persistance.Context;
using ReadEase.WebApi.Middleware;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddPersistanceServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddTransient<ExceptionMiddleware>();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ILoanService, LoanService>();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookGenreRepository, BookGenreRepository>();
builder.Services.AddScoped<ILoanRepository, LoanRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork<BaseDbContext>>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//builder.Host.UseSerilog((context,conf) => conf.ReadFrom.Configuration(context.Configuration));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseSerilogRequestLogging();

app.UseMiddlewareExtensions();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
