using AutoMapper;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using NBU.DAL.Context;
using NBU.UI.InfraStructure;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
// Get Connection string from Configration class
var appSettion = new AppConfigrations();
builder.Services.AddDbContext<SqlDbContext>(x => x.UseSqlServer(appSettion.sqlConnectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Additional Configrations
// inject installer class
InjectionConfigration installer = new InjectionConfigration();
installer.ConfigureServices(builder.Services);

// Inject Automapper
builder.Services.AddAutoMapper(typeof(MappingProfile));
// Localization
#region Localization

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddControllersWithViews()
    .AddViewLocalization
    (LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { "en-US", "ar" };
    options.SetDefaultCulture(supportedCultures[0])
        .AddSupportedCultures(supportedCultures)
        .AddSupportedUICultures(supportedCultures);
});
var app = builder.Build();
var supportedCultures = new[] { "en-US", "ar" };

// Culture from the HttpRequest
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);
#endregion
#endregion

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
