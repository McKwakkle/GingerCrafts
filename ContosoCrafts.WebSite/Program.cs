using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllers();
builder.Services.AddTransient<JsonFileProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapBlazorHub();

//app.MapGet("/products", (context) =>
//{
//    var jsonProductsService = app.Services.GetService<JsonFileProductService>();
//    var products = jsonProductsService?.GetProducts();
//    var json = JsonSerializer.Serialize<IEnumerable<Product>>(products);

//    return context.Response.WriteAsync(json);
//});

app.Run();
