using BartenderAcademy.Application.Behaviors;
using BartenderAcademy.Application.Interfaces;
using BartenderAcademy.Application.Interfaces.Repositories;   // ← add this
using BartenderAcademy.Infrastructure.Persistence;
using BartenderAcademy.Infrastructure.Repositories;         // ← add this
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BartenderAcademy.API.Services;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 1. Register MediatR (v11 style). We use ICurrentUserService as the “anchor” type
builder.Services.AddMediatR(typeof(ICurrentUserService).Assembly);

// 2. Register all FluentValidation validators from the Application assembly
builder.Services.AddValidatorsFromAssemblyContaining<ICurrentUserService>();

// 3. Register pipeline behaviors
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

// 4. Register EF Core DbContext as IApplicationDbContext
//    (reads “DefaultConnection” from appsettings.json)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//    Make IApplicationDbContext resolve to the same ApplicationDbContext
builder.Services.AddScoped<IApplicationDbContext>(provider =>
    provider.GetRequiredService<ApplicationDbContext>());

// 5. Register the generic repository
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

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
