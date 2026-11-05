using Microsoft.EntityFrameworkCore;
using WebSallesMvc.Data;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("WebSallesMvcContext") ?? throw new InvalidOperationException("Connection string 'WebSallesMvcContext' not found.");

builder.Services.AddDbContext<WebSallesMvcContext>(
    options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<SeedingService>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    using (var scope = app.Services.CreateScope())
    {
        var seedingService = scope.ServiceProvider.GetRequiredService<SeedingService>();
        seedingService.Seed();
    }
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
   .WithStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
