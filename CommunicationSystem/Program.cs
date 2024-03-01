global using CommunicationSystem.Areas.Auth.ViewModels;
global using System.ComponentModel.DataAnnotations;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using CommunicationSystem.Data;
global using Microsoft.AspNetCore.Mvc;
global using CommunicationSystem.Repository;
global using CommunicationSystem.Areas.Auth.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDBContext>(o =>
    {
        o.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
    });
builder.Services.AddIdentity<AppUser, IdentityRole>(o => { o.SignIn.RequireConfirmedEmail = false; })
                .AddEntityFrameworkStores<AppDBContext>()
                .AddDefaultTokenProviders();
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IAccount, AccountRepository>();
builder.Services.AddTransient<IAppointment, AppointmentRepository>();
builder.Services.AddTransient<ICar, CarRepository>();
builder.Services.AddTransient<IEngineer, EngineerRepository>();
builder.Services.AddTransient<IMessage, MessageRepository>();
builder.Services.AddTransient<IOwner, OwnerRepository>();
builder.Services.AddTransient<IServiceHistory, ServiceHistoryRepository>();
builder.Services.AddTransient<IServiceType, ServiceTypeRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
//pattern: "{area=Auth}/{controller=Dashboard}/{action=Index}/{id?}");
pattern: "{area=Web}/{controller=Home}/{action=Index}/{id?}");

app.Run();
