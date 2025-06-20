using ERMS.DAL.Auth;
using ERMS.DL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AuthContext>(options =>
    options.UseSqlServer(connectionString));

// Identity setup
builder.Services.AddDefaultIdentity<IdentityAuthUserModel>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<AuthContext>()
.AddDefaultTokenProviders()
    .AddDefaultUI();

// Add Authentication Middleware
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.LogoutPath = "/Identity/Account/Logout";
    //options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.SlidingExpiration = true;
});


builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/"); // Protect all pages
    options.Conventions.AllowAnonymousToPage("/Identity/Account/Login"); // Allow Login page
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapRazorPages();

app.Run();
