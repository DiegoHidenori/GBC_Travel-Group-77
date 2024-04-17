using GBC_Travel_Group_77.Data;
using GBC_Travel_Group_77.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using GBC_Travel_Group_77.Services;
using GBC_Travel_Group_77.Areas.ProjectManagement.Models;

// Serilog
using Serilog;
using GBC_Travel_Group_77.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AppDbContext>();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultUI()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSingleton<IEmailSender, EmailSender>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
builder.Services.AddRazorPages();


// Email functionality
builder.Services.AddSingleton<IEmailSender, EmailSender>();



// Serilog & session service
builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
{
    loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration);
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddSession();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}


// Middleware
app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<ErrorHandlingMiddleware>();


// What does this do????????????????
using var scope = app.Services.CreateScope();
var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();

try
{
    AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    await ContextSeed.SeedRolesAsync(userManager, roleManager);
    await ContextSeed.SeedAdminAsync(userManager, roleManager);
}
catch (Exception e)
{
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(e, "An error occurred seeding the roles for the system");
}

app.MapDefaultControllerRoute();
app.UseRouting();


// Authentication
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();


// Session service
app.UseSession();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

DbInitializer.Seed(app);
app.Run();
