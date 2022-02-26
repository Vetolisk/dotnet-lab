

using Lab3.Context;
using Lab3.Interfaces;
using Lab3.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options => //CookieAuthenticationOptions
        {
            options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
        });
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DbContext, DataContext>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IOrderManager, OrderManager>();
var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
