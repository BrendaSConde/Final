using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ControlVendedores.Data;
using ControlVendedores.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<VentaContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("VentaContext") ?? throw new InvalidOperationException("Connection string 'VentaContext' not found.")));

// Add services to the container.
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<VentaContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ISucursalService, SucursalService>();
builder.Services.AddScoped<IVendedorService, VendedorService>();
builder.Services.AddScoped<IVentaService, VentaService>();

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
