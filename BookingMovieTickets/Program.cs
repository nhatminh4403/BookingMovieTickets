using BookingMovieTickets.Models;
using BookingMovieTickets.Repository.EF;
using BookingMovieTickets.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MoviesBooking.DataAccess;
using MoviesBooking.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MoviesBookingDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<I_FilmRepository, EF_FilmRepository>();
builder.Services.AddScoped<I_FilmCategoryRepository, EF_FilmCategoryRepository>();
builder.Services.AddScoped<I_Seat, EF_Seat>();
builder.Services.AddScoped<I_Receipt, EF_Receipt>(); 
builder.Services.AddScoped<I_FilmDetail, EF_FilmDetail>();
builder.Services.AddScoped<I_Schedule, EF_Schedule>(); 
builder.Services.AddScoped<I_PremiereTime, EF_PremiereTime>(); 
builder.Services.AddScoped<I_Theater, EF_Theater>();
builder.Services.AddScoped<I_TheatreRoom, EF_Room>();
builder.Services.AddScoped<I_Ticket, EF_Ticket>();
builder.Services.AddScoped<I_TicketDetail, EF_TicketDetail>();
builder.Services.AddScoped<I_ReceiptDetail, EF_ReceiptDetail>();

builder.Services.AddIdentity<UserInfo, IdentityRole>()
 .AddDefaultTokenProviders()
 .AddDefaultUI()
 .AddEntityFrameworkStores<MoviesBookingDBContext>();
builder.Services.AddRazorPages();


builder.Services.ConfigureApplicationCookie(option =>
{
    option.LoginPath = $"/Identity/Account/Login";
    option.LogoutPath = $"/Identity/Account/Logout";
    option.LogoutPath = $"/Identity/Account/AccessDenied";

});

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
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
