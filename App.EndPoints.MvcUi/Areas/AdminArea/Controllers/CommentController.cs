using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Dtos.CommentDtos;
using App.EndPoints.MvcUi.Areas.AdminArea.ViewModels.Comments;
using App.Frameworks.Web.DateConverter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace App.EndPoints.MvcUi.Areas.AdminArea.Controllers
{
    public class CommentController : AdminBaseController
    {
         protected readonly ICommentAppServices _commentApp;

        public CommentController(ICommentAppServices commentApp)
        {
            _commentApp = commentApp;
        }

        public  async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            var result = await _commentApp.GetAll(cancellationToken);

            List<AllCommentViewModel> commentsViewModel = result.Select<CommentOutputDto, AllCommentViewModel>(c => new AllCommentViewModel
                 {
                     Id = c.Id,
                     ProductName = c.Product.Name,
                     CsutomerName = c.Customer.FirstName + " " + c.Customer.LastName,
                     CommentText = c.Text,
                     CreatedAt = c.CreatedAt.ToPersianDate(),
                     IsConfirmed = c.IsConfirmed
            }).OrderBy(c => c.IsConfirmed).ThenBy(c => c.CreatedAt) .ToList();

            return View(commentsViewModel);
        }

        public  async Task<ActionResult> Details(int id)
        {
            return View();
        }

        public  async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<ActionResult> Create(IFormCollection collection)
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

        public  async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<ActionResult> Edit(int id, IFormCollection collection)
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

        public  async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<ActionResult> Delete(int id, IFormCollection collection)
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
