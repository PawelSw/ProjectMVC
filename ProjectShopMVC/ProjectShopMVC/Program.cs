using Microsoft.EntityFrameworkCore;
using ProjectShopMVC.Models;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ProjectDbContext>(options => {
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:ProjectsDbContextConnection"]);
});


builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();




var app = builder.Build();
app.UseStaticFiles();
app.UseSession();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();


DbSeeder.Seed(app);
app.Run();
