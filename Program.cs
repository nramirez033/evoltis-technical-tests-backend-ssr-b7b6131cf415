using Microsoft.EntityFrameworkCore;
using technical_tests_backend_ssr.Repositories;
using technical_tests_backend_ssr.Services;
using technical_tests_backend_ssr.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDev",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//configurar Entity Framework Core con MySQL
builder.Services.AddDbContext<TechnicalTestDbContext>(opt => 
    opt.UseMySql(connectionString,
        new MySqlServerVersion(ServerVersion.AutoDetect(connectionString))
    )
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngularDev");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
