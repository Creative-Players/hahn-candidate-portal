using FluentValidation;
using Hahn.Application.DAL.Data;
using Hahn.Application.DAL.Repositories;
using Hahn.Application.Domain.Entities;
using Hahn.Application.Domain.Interfaces;
using Hahn.Application.Domain.Models;
using Hahn.Application.Domain.Services;
using Hahn.Application.Web.Helpers.ModelValidations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<HahnApplicationDbContext>(options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("HahnApplicationDbContext")));

builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddScoped<ICandidateService, CandidateService>();
builder.Services.AddScoped<IJobOptionService, JobOptionService>();
builder.Services.AddScoped<IRepository<Candidate>, BaseEFRepository<Candidate>>();
builder.Services.AddScoped<IRepository<JobOption>, BaseEFRepository<JobOption>>();
builder.Services.AddTransient<IValidator<CandidateModel>, CandidateValidator>();
builder.Services.AddTransient<IValidator<JobOptionModel>, JobOptionValidator>();
builder.Services.AddControllers()
    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        var frontend_url = builder.Configuration.GetValue<string>("frontend_url");
        policy.WithOrigins(frontend_url).AllowAnyHeader().AllowAnyMethod();
    });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hahn Application  API v1");
    });
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hahn Application  API v1");
});
app.MapHealthChecks("/health");
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();


