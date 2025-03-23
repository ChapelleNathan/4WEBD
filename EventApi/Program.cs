using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using EventApi.Data;

var builder = WebApplication.CreateBuilder(args);

var dBConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<DataContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();