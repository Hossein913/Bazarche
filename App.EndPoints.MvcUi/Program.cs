using App.Domain.AppServices.Booth;
using App.Domain.AppServices.Product;
using App.Domain.AppServices.User;
using App.Domain.Core._Booth.Contracts.AppServices;
using App.Domain.Core._Booth.Contracts.Repositories;
using App.Domain.Core._Booth.Contracts.Services;
using App.Domain.Core._Common.Contracts.Repositories;
using App.Domain.Core._Common.Contracts.Services;
using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._Products.Contracts.Services;
using App.Domain.Core._User.Contracts.AppServices;
using App.Domain.Core._User.Contracts.Repositories;
using App.Domain.Core._User.Entities;
using App.Domain.Services.Booth;
using App.Domain.Services.Common;
using App.Domain.Services.Product;
using App.Infra.Data.Repos.Ef.Booths;
using App.Infra.Data.Repos.Ef.Commons;
using App.Infra.Data.Repos.Ef.Products;
using App.Infra.Data.Repos.Ef.Users;
using App.Infra.Data.SqlServer.Ef.DbCntx;
using Infrastructure.IdentityConfigs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//--DbContext
builder.Services.AddDbContext<BazarcheContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

# region Ripository Injections
//--Booths
builder.Services.AddScoped<IBoothRepository, BoothRepository > ();
builder.Services.AddScoped<IMedalRepository, MedalRepository > ();
//--Commons
builder.Services.AddScoped<IPictureRepository, PictureRepository > ();
//--Products
builder.Services.AddScoped<IBidRepository, BidRepository > ();
builder.Services.AddScoped<IBoothProductRepository, BoothProductRepository > ();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository > ();
builder.Services.AddScoped<ICommentRepository, CommentRepository > ();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository > ();
builder.Services.AddScoped<IOrderRepository, OrderRepository > ();
builder.Services.AddScoped<IAuctionRepository, AuctionRepository > ();
builder.Services.AddScoped<IProductRepository, ProductRepository > ();
//--Users
builder.Services.AddScoped<IAddressRepository, AddressRepository > ();
builder.Services.AddScoped<IAdminRepository, AdminRepository > ();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository > ();
builder.Services.AddScoped<ISellerRepository, SellerRepository > ();
builder.Services.AddScoped<IWageRepository, WageRepository>();
#endregion

# region Services Injections
//--Booths
builder.Services.AddScoped<IBoothServices, BoothServices>();
builder.Services.AddScoped<IMedalServices, MedalServices>();
//--Commons
builder.Services.AddScoped<IPictureServices, PictureServices>();
//--Products
builder.Services.AddScoped<IAuctionServices, AuctionServices>();
builder.Services.AddScoped<IBidServices, BidServices>();
builder.Services.AddScoped<IBoothProductServices, BoothProductServices>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<ICommentServices, CommentServices>();
builder.Services.AddScoped<IOrderItemServices, OrderItemServices>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<IProductServices, ProductServices>();
//--Users
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ISellerRepository, SellerRepository>();

#endregion

# region AppServices Injections

builder.Services.AddScoped<IBoothAppServices, BoothAppServices>();
//builder.Services.AddScoped<IMedalServices, MedalServices>();

////--Commons
//builder.Services.AddScoped<IPictureServices, PictureServices>();

////--Products
//builder.Services.AddScoped<IAuctionServices, AuctionServices>();
//builder.Services.AddScoped<IBidServices, BidServices>();
//builder.Services.AddScoped<IBoothProductServices, BoothProductServices>();
builder.Services.AddScoped<ICategoryAppServices, CategoryAppServices>();
//builder.Services.AddScoped<ICommentServices, CommentServices>();
//builder.Services.AddScoped<IOrderItemServices, OrderItemServices>();
//builder.Services.AddScoped<IOrderServices, OrderServices>();
//builder.Services.AddScoped<IProductServices, ProductServices>();

////--Users
//builder.Services.AddScoped<IAddressRepository, AddressRepository>();
//builder.Services.AddScoped<IAdminRepository, AdminRepository>();
//builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
//builder.Services.AddScoped<ISellerRepository, SellerRepository>();
builder.Services.AddScoped<IIdentityAppServices, IdentityAppServices>();
#endregion

# region Identity
builder.Services.AddIdentity<AppUser, AppRole>()
.AddEntityFrameworkStores<BazarcheContext>()
.AddRoles<AppRole>()
.AddErrorDescriber<CustomIdentityError>();

builder.Services.Configure<IdentityOptions>(option =>
{
    //UserSetting
    //option.User.AllowedUserNameCharacters = "abcd123";
    option.User.RequireUniqueEmail = true;

    //Password Setting
    option.Password.RequireDigit = false;
    option.Password.RequireLowercase = false;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireUppercase = false;
    option.Password.RequiredLength = 4;
    option.Password.RequiredUniqueChars = 1;

    //Lokout Setting
    option.Lockout.MaxFailedAccessAttempts = 3;
    option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMilliseconds(10);

    //SignIn Setting
    option.SignIn.RequireConfirmedAccount = false;
    option.SignIn.RequireConfirmedEmail = false;
    option.SignIn.RequireConfirmedPhoneNumber = false;

});

builder.Services.ConfigureApplicationCookie(option =>
{
    // cookie setting
    option.ExpireTimeSpan = TimeSpan.FromMinutes(10);

    option.LoginPath = "/Authenticate/login";
    option.AccessDeniedPath = "/Authenticate/AccessDenied";
    option.SlidingExpiration = true;
});


// ---set Authorazation to All endpoints.
builder.Services.AddMvc(Option =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    Option.Filters.Add(new AuthorizeFilter(policy));
});

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline
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
name: "Admin",
pattern: "{area:exists}/{controller=AdminPanel}/{action=Index}/{id?}");

app.MapControllerRoute(
name: "Customer",
pattern: "{area:exists}/{controller=CustomerPanel}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
