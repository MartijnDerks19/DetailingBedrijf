using DataLaag.DataToegang;
using LogicaLaag.DTOs;
using LogicaLaag.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ICRUDCollectie<DetailerDTO>, DetailerDataToegang>();
builder.Services.AddTransient<ICRUDCollectie<AutoDTO>, AutoDataToegang>();
builder.Services.AddTransient<ICRUDCollectie<AutoEigenaarDTO>, AutoEigenaarDataToegang>();

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
