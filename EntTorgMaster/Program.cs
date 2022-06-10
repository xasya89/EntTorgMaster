using EntTorgMaster.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Services;
using Microsoft.EntityFrameworkCore;

using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;

using EntTorgMaster.Mappings;
using EntTorgMaster.Data;
using EntTorgMaster.Services;
using EntTorgMaster.Infrastructure;
using Microsoft.AspNetCore.Components.Authorization;
using EntTorgMaster;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<GoodService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ContractorService>();
builder.Services.AddMudServices();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
builder.Services.AddScoped<AuthenticationStateProvider, TokenAuthenticationStateProvider>();

//Mappings
builder.Services.AddAutoMapper(typeof(MappingOrder));

builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();


builder.Services.AddDbContextFactory<enttorgsnabContext>(opt =>
{
    opt.UseMySql(builder.Configuration.GetConnectionString("MySQL"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));
});

var app = builder.Build();


var dbfactory = (IDbContextFactory<enttorgsnabContext>)app.Services.GetRequiredService(typeof(IDbContextFactory<enttorgsnabContext>));
using (var db = dbfactory.CreateDbContext())
    db.Database.Migrate();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
ImageGenerate.Create(new OrderDoor {H=2010, W=1800, Open=OpenType.Right, SEqual=true, FramugaH=400, NavesCount=3, NavesStvorkaCount=4 });

app.Run();
