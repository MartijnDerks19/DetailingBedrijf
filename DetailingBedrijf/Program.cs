using System.Drawing;
using DataLaag.DataToegang;
using DomeinLaag.DTOs;
using DomeinLaag.Interfaces;
using Org.BouncyCastle.Crypto.Parameters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IDetailer, DetailerDataToegang>();
builder.Services.AddTransient<IAuto, AutoDataToegang>();
builder.Services.AddTransient<IAutoEigenaar, AutoEigenaarDataToegang>();
builder.Services.AddTransient<IAfspraak, AfspraakDataToegang>();

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
    pattern: "{controller=AutoEigenaar}/{action=Index}/{id?}");

app.Run();
