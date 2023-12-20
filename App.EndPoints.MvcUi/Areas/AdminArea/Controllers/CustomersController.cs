using App.Domain.Core._User.Contracts.AppServices;
using App.Domain.Core._User.Dtos.CustomersDtos.CustomerAppServiceDto;
using App.Domain.Core._User.Entities;
using App.Domain.Core._User.Enums;
using App.EndPoints.MvcUi.Areas.AdminArea.ViewModels.Customers;
using App.Frameworks.Web.DateConverter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace App.EndPoints.MvcUi.Areas.AdminArea.Controllers;

    public class CustomersController : AdminBaseController
    {
        private readonly ICustomerAppServices _customerAppServices;
        private readonly IAddressAppServices _addressApp;
        protected readonly IWebHostEnvironment _webHostEnvironment;

    public CustomersController(ICustomerAppServices customerAppServices, IAddressAppServices addressApp, IWebHostEnvironment webHostEnvironment)
    {
        _customerAppServices = customerAppServices;
        _addressApp = addressApp;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            var result = await _customerAppServices.GetAll(cancellationToken);
            var ViewModel = result.Select(c => 
            new GetAllCustomersViewModel {
                Id = c.Id ,
                Firstname = c.Firstname ,
                Lastname = c.Lastname ,
                //Sexuality = c.Sexuality ,
                ProfilePicFile = c.ProfilePicFile ,
                CartOrderId = c.CartOrderId ,
                AppUser = c.AppUser ,
                OrderCount = c.OrdersCount,
            }).ToList();
            return View(ViewModel);
        }

        public async Task<ActionResult> Details(int customerId, CancellationToken cancellationToken)
        {
            var result = await _customerAppServices.GetDetailsWithRelation(customerId,cancellationToken);
            GetCustomerDetailsViewModel viewModel = new GetCustomerDetailsViewModel {
                Id = result.Id,
                Firstname = result.Firstname,
                Lastname = result.Lastname,
                Sexuality = result.Sexuality,
                ProfilePicFile = result.ProfilePicFile,
                //AddressId = result.AddressId,
                CartOrderId = result.CartOrderId,
                Birthdate = result.Birthdate,
                Wallet = result.Wallet,
                AppUserId = result.AppUserId,
                //OrdersCount = result.OrdersCount,
                Address = result.Address,
                //Auctions = result.Auctions,
                //Bids = result.Bids,
                Comments = result.Comments,
                Orders = result.Orders,
                //ProfilePic = result.ProfilePic,
                AppUser = result.AppUser,
            };
            return View(viewModel);
        }

        public async Task<ActionResult> Create(CancellationToken cancellationToken)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection, CancellationToken cancellationToken)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int customerId, CancellationToken cancellationToken)
        {
            var resutl =await _customerAppServices.GetDetails(customerId, cancellationToken);
            var provinces = await _addressApp.GetAllProvinces(cancellationToken);
            UpdateCustomerViewModel updateCustomer = new UpdateCustomerViewModel
            {
                Id = resutl.Id ,
                Firstname = resutl.Firstname ,
                Lastname = resutl.Lastname ,
                SexualityId = (int)resutl.Sexuality ,
                ProfilePicFile = resutl.ProfilePicFile ,
                ProfilePicId = resutl.ProfilePicId,
                Birthdate = resutl.Birthdate.ToPersianNumericDate(),
                ProvinceId = resutl.Address.ProvinceId,
                City = resutl.Address.City ,
                FullAddress = resutl.Address.FullAddress , 
                PostalCode = resutl.Address.PostalCode , 
                Provinces = provinces,
            };
             
            return View(updateCustomer);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdateCustomerViewModel updateCustomer, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                CustomerAppServiceUpdateDto UpdatecustomerDto = new CustomerAppServiceUpdateDto
                {
                    Id = updateCustomer.Id,
                    FirstName = updateCustomer.Firstname,
                    LastName = updateCustomer.Lastname,
                    Birthdate = ConvertTo.GregorianDate(updateCustomer.Birthdate),
                    SexualityId = (CustomerSexuality)updateCustomer.SexualityId,
                    UploadProfilePic = updateCustomer.UploadProfilePic,
                    ProfilePicId = updateCustomer.ProfilePicId,
                    ProvinceId = updateCustomer.ProvinceId,
                    City = updateCustomer.City,
                    FullAddress = updateCustomer.FullAddress,
                    PostalCode = updateCustomer.PostalCode,
                };

                var resutl = await _customerAppServices.Update(UpdatecustomerDto,CurrentUserId, _webHostEnvironment.WebRootPath, cancellationToken);
                if (resutl == "success") 
                {
                    return RedirectToAction(nameof(Details),new {customerId = updateCustomer.Id });
                }
                else
                {
                    ModelState.AddModelError("Birthdate", resutl);
                }

            }
            var provinces = await _addressApp.GetAllProvinces(cancellationToken);
            updateCustomer.Provinces = provinces;
            return View(updateCustomer);

        }

        public async Task<ActionResult> Delete(int customerId, CancellationToken cancellationToken)
        {
            await _customerAppServices.SoftDelete(customerId, cancellationToken);
            return Redirect("Index");
        }

        public async Task<ActionResult> SetActivity(int appUserId,bool status, CancellationToken cancellationToken)
        {
            await _customerAppServices.SetActivity(appUserId, status, cancellationToken);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete( IFormCollection collection, CancellationToken cancellationToken)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
