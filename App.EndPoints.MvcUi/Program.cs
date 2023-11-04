using App.Domain.Core._Booth.Contracts.Repositories;
using App.Domain.Core._Common.Contracts.Repositories;
using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._User.Contracts.Repositories;
using App.Infra.Data.Repos.Ef.Booths;
using App.Infra.Data.Repos.Ef.Commons;
using App.Infra.Data.Repos.Ef.Products;
using App.Infra.Data.Repos.Ef.Users;
using App.Infra.Data.SqlServer.Ef.DbCntx;
using Microsoft.EntityFrameworkCore;

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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
