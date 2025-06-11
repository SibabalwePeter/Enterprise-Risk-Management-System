using ERMS.api;
using ERMS.DAL.Data;
using ERMS.services.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ REGISTER ALL DEPENDENCIES FIRST
builder.Services.AddApiDI(builder.Configuration);
var sp = builder.Services.BuildServiceProvider();
var ctx = sp.GetService<AppDbContext>();
var test = ctx != null ? "✅ AppDbContext resolved" : "❌ Failed to resolve";

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
