using Example_API.Models;
using Example_API.Services;
using Example_API.Middlewares;
using Example_API.Response;
using Example_API;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StudyAppContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudyContext"));
});

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<INotaService, NotaService>();
builder.Services.AddScoped<ICustomService, CustomService>();
builder.Services.AddScoped<IContext, CustomContext>();

var app = builder.Build();

// using(var scope = app.Services.CreateScope()){
//     var context = scope.ServiceProvider.GetRequiredService<StudyAppContext>();
//     context.Database.Migrate();
// }

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseTestMiddleware();

app.MapControllers();





app.Run();
