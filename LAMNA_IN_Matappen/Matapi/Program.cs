using Matapi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Lägg till DbContext med SQLite
builder.Services.AddDbContext<MatApiContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MatApiConnection")));

// Lägg till CORS för frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

// Lägg till controllers
builder.Services.AddControllers();

// Lägg till Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MatApi",
        Version = "v1",
        Description = "En API för att hantera maträtter"
    });
});

var app = builder.Build();

app.UseCors("AllowAll");

// Använd Swagger för dokumentation
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "MatApi v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
