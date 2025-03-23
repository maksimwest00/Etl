using Etl.Application.UniversityManagment;
using Etl.Application.UniversityManagment.CreateUniversity;
using Etl.Application.UniversityManagment.Queries.GetUniversitiesByFilters;
using Etl.Infrastructure;
using Etl.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();


builder.Services.AddScoped<ApplicationDbContext>();

builder.Services.AddScoped<CreateUniversityHandler>();
builder.Services.AddScoped<GetUniversitiesByFiltersHandler>();
builder.Services.AddScoped<IUniversitiesRepository, UniversitiesRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
