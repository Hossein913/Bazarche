using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MvcUi.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CustomerPanelController : Controller
    {
        // GET: CustomerPanelController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CustomerPanelController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerPanelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerPanelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CustomerPanelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerPanelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: CustomerPanelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerPanelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
}
