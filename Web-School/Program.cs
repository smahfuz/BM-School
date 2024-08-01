using Microsoft.EntityFrameworkCore;
using REPO.DATA;
using REPO.IRepositories;
using REPO.Repositories;
using SERVICE.IServices;
using SERVICE.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IClasslevelRepository, ClassLevelRepository>();
builder.Services.AddScoped<IDesignationRepository, DesignationRepository>();


builder.Services.AddScoped<IClassLevelService, ClasslevelService>();
builder.Services.AddScoped<IDesignationService, DesignationService>();

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

app.Run();
