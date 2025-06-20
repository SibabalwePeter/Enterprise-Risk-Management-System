using ERMS.DL.Models;
using ERMS.DAL.Auth;
using ERMS.DAL.Data;
using ERMS.DL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ERMS.DAL;

var builder = WebApplication.CreateBuilder(args);

// ----------------------------------------------------------
// Configure Services
// ----------------------------------------------------------

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<AuthContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentityCore<IdentityAuthUserModel>()
    .AddEntityFrameworkStores<AuthContext>()
    .AddApiEndpoints(); // For .MapIdentityApi()

builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
    .AddCookie(IdentityConstants.ApplicationScheme); // Optional: can be extended with JWT etc.

builder.Services.AddAuthorization();

builder.Services.AddScoped<IProductService, ProductService>();

// ----------------------------------------------------------
// Build & Configure Middleware
// ----------------------------------------------------------

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapIdentityApi<IdentityAuthUserModel>();

app.Run();
