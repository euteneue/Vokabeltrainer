using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VokabelTrainerAPI.Data;
var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<VokabelTrainerAPIContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("VokabelTrainerAPIContext")));

//builder.Services.AddDbContext<VokabelTrainerAPIContext>(options =>
//    options.UseSqlite(builder.Configuration.GetConnectionString("VokabelTrainerAPIContext")));

builder.Services.AddDbContext<VokabelTrainerAPIContext>(options =>
    options.UseSqlite("Data Source=C:\\temp\\vokabeln.db"));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var ctx = services.GetRequiredService<VokabelTrainerAPIContext>();

    ctx.Database.EnsureCreated();
    DbInitializer.Initialize(ctx);
}

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
