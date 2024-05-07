using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prac_assignments;
using Prac_assignments.Repository;
using Prac_assignments.TenantDbContext;

var builder = WebApplication.CreateBuilder(args);
IMapper mapper = MappingConfiguration.RegisterMaps().CreateMapper();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TenantDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PracticeDB")));

builder.Services.AddDbContext<TenantDBContext>();
builder.Services.AddHttpClient();
builder.Services.AddSingleton(mapper);
builder.Services.AddScoped<IUserRepository, UserRepository>(); 

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
