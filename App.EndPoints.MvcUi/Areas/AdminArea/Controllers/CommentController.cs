using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Dtos.CommentDtos;
using App.EndPoints.MvcUi.Areas.AdminArea.ViewModels.Comments;
using App.EndPoints.MvcUi.Models._Comment;
using App.Frameworks.Web.DateConverter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;

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
                     ProductId = c.Product.Id,
                     CsutomerName = c.Customer.FirstName + " " + c.Customer.LastName,
                     CommentText = c.Text,
                     CreatedAt = c.CreatedAt.ToPersianAlfabeticDate(),
                     IsConfirmed = c.IsConfirmed
            }).OrderBy(c => c.IsConfirmed).ThenBy(c => c.CreatedAt) .ToList();

            return View(commentsViewModel);
        }

        public async Task<ActionResult> Edit(int commentId, CancellationToken cancellationToken)
        {
            var comment = await _commentApp.GetDetail(commentId, cancellationToken);
            EditCommentViewModel commentView = new EditCommentViewModel
            {
                Id = comment.Id,
                Text = comment.Text,
                ProductName = comment.Product.Name,
                CustomerFullName = comment.Customer.FirstName+" "+ comment.Customer.LastName,
                ProductId = comment.Product.Id,
                CustomerId = comment.Customer.Id,

            };
            return View(commentView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditCommentViewModel editComment, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                CommentUpdateDto commentUpdate = new CommentUpdateDto
                {
                    Id = editComment.Id,
                    Text = editComment.Text,
                     
                };
                await _commentApp.Update(commentUpdate, cancellationToken);
                return RedirectToAction("Index");
            }

            return View(editComment);
        }

        public async Task<ActionResult> Delete(int commentId, CancellationToken cancellationToken)
        {
            await _commentApp.SoftDelete(commentId, cancellationToken);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Confirmation(int commentId, bool status, CancellationToken cancellationToken)
        {
            CommentUpdateDto commentUpdate = new CommentUpdateDto
            {
                Id = commentId,
                IsConfirmed = status,
            };
            await _commentApp.Update(commentUpdate, cancellationToken);
            return RedirectToAction("Index");
        }


        public  async Task<ActionResult> Details(int id)
        {
            return View();
        }

      





    }
}
