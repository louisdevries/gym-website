using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GymWebsite.Models; // Your User model namespace

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add PostgreSQL Database context
builder.Services.AddDbContext<WarriorWisdomContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Identity services (for user authentication)
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<WarriorWisdomContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

// Serve static files from wwwroot
app.UseStaticFiles();

// Serve default files (like index.html) from wwwroot
app.UseDefaultFiles();

app.UseAuthentication();  // Add this line to enable authentication
app.UseAuthorization();   // Add this line to enable authorization

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
