
using Microsoft.EntityFrameworkCore;
using projeodev.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(5000);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddDbContext<DataContext>(options=> options.UseSqlServer(builder.Configuration.GetConnectionString("CS1")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
var httpContextAccessor = app.Services.GetRequiredService<IHttpContextAccessor>();
SessionHelper.Configure(httpContextAccessor);

app.MapControllerRoute(
    name: "default",
    pattern:"{controller=Home}/{action=Index}/{id?}"
    );

//app.MapRazorPages();

app.Run();
