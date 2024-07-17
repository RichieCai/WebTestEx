using Microsoft.EntityFrameworkCore;
using WebTestEx.Context;
using WebTestEx.Interface;
using WebTestEx.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddDbContext<dbCustomDbSampleContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbCustomDbSampleConnection"));

});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
