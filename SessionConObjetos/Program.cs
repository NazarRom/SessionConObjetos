using Microsoft.EntityFrameworkCore;
using SessionConObjetos.Data;
using SessionConObjetos.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//session
builder.Services.AddResponseCaching();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});


string connecionString = builder.Configuration.GetConnectionString("SqlCasa");
builder.Services.AddTransient<RepositoryRestaurantes>();
builder.Services.AddDbContext<RestaurantesContext>(options => options.UseSqlServer(connecionString));

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

app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Restaurante}/{action=Index}/{id?}");

app.Run();
