using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MvcHamburgerProje.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<Kullanici>();
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<Kullanici>(options => options.SignIn.RequireConfirmedAccount = false)
	.AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    if (!await roleManager.RoleExistsAsync("Administrator"))
    {
        await roleManager.CreateAsync(new IdentityRole("Administrator"));
    }
    if (!await roleManager.RoleExistsAsync("Musteri"))
    {
        await roleManager.CreateAsync(new IdentityRole("Musteri"));
    }

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Kullanici>>();

    if (!await userManager.Users.AnyAsync(x => x.UserName == "admin@example.com"))
    {
        var adminUser = new Kullanici()
        {
            Ad = "Admin",
            Soyad = "Admin",
            UserName = "admin@example.com",
            Email = "admin@example.com",
            Adres = "AdminAdres",
            EmailConfirmed = true
        };
        await userManager.CreateAsync(adminUser, "Ankara1.");
        await userManager.AddToRoleAsync(adminUser, "Administrator");
    }

    if (!await userManager.Users.AnyAsync(x => x.UserName == "musteri@example.com"))
    {
        var adminUser = new Kullanici()
        {
            UserName = "musteri@example.com",
            Email = "musteri@example.com",
            EmailConfirmed = true,
            Ad="Ali",
            Soyad="Kara",
            Adres="AliKaraAdres"
        };
        await userManager.CreateAsync(adminUser, "Ankara1.");
        await userManager.AddToRoleAsync(adminUser, "Musteri");
    }

}

app.Run();
