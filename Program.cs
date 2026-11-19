using CodespacesBlank.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using CodespacesBlank.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//my dbcontext config
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
   // options.UseSqlServer(connectionString); this is for a database

   //this is for Inmemory
   options.UseInMemoryDatabase("CodespacesBlank");
});

var app = builder.Build();

//add product sample data

await using var scope = app.Services.CreateAsyncScope();
var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

if (!await db.Products.AnyAsync())
{
    db.Products.AddRange(
        new Products
        {
            Name = "Desk lamp",
            Brand = "Demo",
            Category = "Lighting",
            Price = 24.99m,
            Description = "Sample product",
            ImageFileName = "OIP.jpg",
            CreatedAt = DateTime.UtcNow
        },
         new Products
        {
            Name = "Iphone",
            Brand = "Demo",
            Category = "Lighting",
            Price = 24.99m,
            Description = "Sample product",
            ImageFileName = "OIP.jpg",
            CreatedAt = DateTime.UtcNow
        },
         new Products
        {
            Name = "Mac Book",
            Brand = "Demo",
            Category = "Lighting",
            Price = 24.99m,
            Description = "Sample product",
            ImageFileName = "OIP.jpg",
            CreatedAt = DateTime.UtcNow
        }
    );

    await db.SaveChangesAsync();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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


app.Run();
