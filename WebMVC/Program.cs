using AutoMapper;
using BusinessLayer;
using DataAccessLayer;
using DTO;
using GifSearchAppMVC.Fillters;
using Logger;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Auto Mapper Configurations
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperProfile());
    mc.AllowNullCollections = true;
});

var  mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


var memoryCache = new MemoryCache(new MemoryCacheOptions() { });
builder.Services.AddSingleton(memoryCache);

builder.Services.AddMvc(options =>
{
    options.Filters.Add<ExceptionFilter>();
});

builder.Services.AddControllersWithViews();



AddServicesContracts(builder);

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

static void AddServicesContracts(WebApplicationBuilder builder)
{
    var logger = new Logger.Logger();
    builder.Services.AddSingleton(logger);
    builder.Services.AddScoped<IGiphyBL, GiphyBL>();
    builder.Services.AddScoped<IWebAPIhandler, WebAPIhandler>();
}