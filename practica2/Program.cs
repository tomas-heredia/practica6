using Repo;
using AutoMapper;
var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
//para automapper
builder.Services.AddAutoMapper(typeof(Program));

// Add services to the container.
builder.Services.AddControllersWithViews();
// Para repositorio  (inyección de dependencia para el repositorio)
builder.Services.AddTransient<IRepoClientes, RepoClientes>();
builder.Services.AddTransient<IRepoUsuario, RepoUsuario>();
builder.Services.AddTransient<IRepoEmpleados, RepoEmpleados>();
builder.Services.AddTransient<IRepoProductos, RepoProducto>();
builder.Services.AddTransient<IRepoProveedor, RepoProveedor>();
//para cookies
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(100000);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
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
//para cookies
app.UseSession();
//app.MapRazorPages();
app.MapDefaultControllerRoute();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
