using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using WeatherApplication.Server.Data;
using WeatherApplication.Server.Models;
using WeatherApplication.Shared.Dtos.OWM;
using WeatherApplication.Shared.Interfaces;
using WeatherApplication.Shared.Services;
using WeatherApplication.Shared.Services.OWM;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();



builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<IWeatherDataStore, WeatherDataStore>();
builder.Services.AddScoped<IWeatherProvider, ConnectOpenWeatherMap>(provider => new ConnectOpenWeatherMap(
    provider.GetService<HttpClient>(),
    provider.GetService<ILogger<ConnectOpenWeatherMap>>(), new OWMSettings()
    {
        APIKey = builder.Configuration.GetSection($"{OWMSettings.Settings}:{nameof(OWMSettings.APIKey)}").Value,
        OneCallAPI = builder.Configuration.GetSection($"{OWMSettings.Settings}:{nameof(OWMSettings.OneCallAPI)}").Value,
        ForecastUrl = builder.Configuration.GetSection($"{OWMSettings.Settings}:{nameof(OWMSettings.ForecastUrl)}").Value,
        CityPref = builder.Configuration.GetSection($"{OWMSettings.Settings}:{nameof(OWMSettings.CityPref)}").Value,
        Metric = builder.Configuration.GetSection($"{OWMSettings.Settings}:{nameof(OWMSettings.Metric)}").Value,
        Lat = builder.Configuration.GetSection($"{OWMSettings.Settings}:{nameof(OWMSettings.Lat)}").Value,
        Lon = builder.Configuration.GetSection($"{OWMSettings.Settings}:{nameof(OWMSettings.Lon)}").Value
    }));
builder.Services.AddScoped<ICityListProvider, CityListProvider>();
builder.Services.AddScoped<HttpClient>();








var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();



