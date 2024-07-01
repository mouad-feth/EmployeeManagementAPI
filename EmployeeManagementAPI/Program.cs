/*

using EmployeeManagementApi.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;
using System.Reflection;
using EmployeeManagementApi.Handlers;
using FluentValidation.AspNetCore;
using EmployeeManagementApi.Commands;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
//builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());



// Add services to the container.
builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

// Add DbContext
builder.Services.AddDbContext<EmployeeContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Initialize Database
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//DatabaseInitializer.InitializeDatabase(connectionString);

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Add services to the container.


// Add MediatR
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
// Register MediatR and specify the assembly where handlers are located
//builder.Services.AddMediatR(typeof(CreateEmployeeCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(CreateEmployeeCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(UpdateEmployeeCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(DeleteEmployeeCommandHandler).Assembly);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

// Configure le pipeline de requêtes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowAngular");

    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
}


app.Run();

*/

using EmployeeManagementApi.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;
using System.Reflection;
using EmployeeManagementApi.Handlers;
using FluentValidation.AspNetCore;
using EmployeeManagementApi.Commands;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

// Add DbContext
builder.Services.AddDbContext<EmployeeContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Add MediatR
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(typeof(CreateEmployeeCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(UpdateEmployeeCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(DeleteEmployeeCommandHandler).Assembly);

var app = builder.Build();

// Ensure migrations and database are up-to-date
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<EmployeeContext>();

    try
    {
        
        //Console.WriteLine("Migrations applied successfully.");
        dbContext.SaveChanges();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while applying migrations.");
        throw; // Rethrow the exception to halt application startup if desired
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();

// CORS configuration
app.UseCors("AllowAngular");

app.MapControllers();

app.Run();
