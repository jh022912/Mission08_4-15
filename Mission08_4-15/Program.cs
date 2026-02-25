using Microsoft.EntityFrameworkCore;
using Mission08_4_15.Data;

// Create the web application builder and load configuration (appsettings.json)
var builder = WebApplication.CreateBuilder(args);

// Add MVC services (controllers + views)
builder.Services.AddControllersWithViews();

// Register Entity Framework DbContext with SQLite
// Connection string is read from appsettings.json "ConnectionStrings:DefaultConnection"
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the Task Repository (Repository Pattern)
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    // In production, use custom error page instead of developer exception page
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Redirect HTTP to HTTPS for security
app.UseHttpsRedirection();
// Enable routing to map URLs to controller actions
app.UseRouting();
// Enable authorization (no auth configured, but pipeline is set up)
app.UseAuthorization();

// Enable static file serving (wwwroot)
app.MapStaticAssets();

// Default route: Home/Quadrants with optional id parameter
app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Quadrants}/{id?}")
    .WithStaticAssets();

app.Run();