﻿using BookingMovieTickets.DataAccess;
using BookingMovieTickets.Models;
using BookingMovieTickets.Repository.EF;
using BookingMovieTickets.Repository.Interface;
using BookingMovieTickets.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDistributedMemoryCache();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddCookie()
.AddGoogle(googleOptions =>
{
    googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
});

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddDbContext<BookingMovieTicketsDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Thêm dịch vụ Hangfire
builder.Services.AddHangfire(config =>
    config.UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHangfireServer();

builder.Services.AddIdentity<UserInfo, IdentityRole>()
       .AddEntityFrameworkStores<BookingMovieTicketsDBContext>()
       .AddDefaultTokenProviders()
       .AddDefaultUI();

builder.Services.AddRazorPages();

builder.Services.AddScoped<I_FilmRepository, EF_FilmRepository>();
builder.Services.AddScoped<I_FilmCategoryRepository, EF_FilmCategoryRepository>();
builder.Services.AddScoped<I_Seat, EF_Seat>();
builder.Services.AddScoped<I_Receipt, EF_Receipt>();
builder.Services.AddScoped<I_Schedule, EF_Schedule>();
builder.Services.AddScoped<I_Theater, EF_Theater>();
builder.Services.AddScoped<I_TheatreRoom, EF_Room>();
builder.Services.AddScoped<I_Ticket, EF_Ticket>();
builder.Services.AddScoped<I_TicketDetail, EF_TicketDetail>();
builder.Services.AddScoped<I_ReceiptDetail, EF_ReceiptDetail>();
builder.Services.AddScoped<I_Cart, EF_Cart>();
builder.Services.AddScoped<I_ScheduleDescription, EF_ScheduleDescription>();
builder.Services.AddScoped<ISeatService, SeatService>();
builder.Services.AddHttpContextAccessor();



builder.Services.AddControllersWithViews();
builder.Services.ConfigureApplicationCookie(option =>
{
    option.LoginPath = $"/Identity/Account/Login";
    option.LogoutPath = $"/Identity/Account/Logout";
    option.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});

var defaultCulture = new CultureInfo("vi-VN");
defaultCulture.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
defaultCulture.DateTimeFormat.DateSeparator = "-";
var supportedCulture = new[] { defaultCulture };

builder.Services.Configure<RequestLocalizationOptions>(option =>
{
    option.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("vi-VN");
    option.SupportedCultures = supportedCulture;
    option.SupportedUICultures = supportedCulture;
});

builder.Services.AddSingleton<IVnPayService, VnPayService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
app.UseSession();

// Cấu hình Hangfire Dashboard và Server
app.UseHangfireDashboard();
app.UseHangfireServer();
RecurringJob.AddOrUpdate<ISeatService>(
    "reset-seats",
    service => service.ResetSeats(),
    "0 0 * * *");
app.MapRazorPages();
#pragma warning disable ASP0014
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Admin",
        pattern: "{area:exists}/{controller=Manager}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
