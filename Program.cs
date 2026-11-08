using Microsoft.EntityFrameworkCore;
using Irimie_Mara_Lab2.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Irimie_Mara_Lab2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Irimie_Mara_Lab2Context")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<Irimie_Mara_Lab2Context>();
// am modificat sa vad daca functioneaza optiune de log in

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
