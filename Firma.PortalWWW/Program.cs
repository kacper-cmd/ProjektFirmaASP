using Firma.Data.Data;//add project reference

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FirmaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FirmaContext") ?? throw new InvalidOperationException("Connection string 'FirmaContext' not found.")));


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
{
    //set short timeout for easy testing)
    options.IdleTimeout = TimeSpan.FromSeconds(40);
    options.Cookie.HttpOnly = true;
    //make the session cookie essential
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
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
