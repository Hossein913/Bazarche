using App.Domain.AppServices.Product;
using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Dtos.CommentDtos;
using App.Domain.Core._Products.Entities;
using App.EndPoints.MvcUi.Models._Comment;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace App.EndPoints.MvcUi.Controllers
{
    public class CommentController :CustomerBaseController
    {
        protected readonly ICommentAppServices _commentApp;
        protected readonly IOrderItemAppServices _orderItemApp;

        public CommentController(ICommentAppServices commentAppServices, IOrderItemAppServices orderItemApp)
        {
            _commentApp = commentAppServices;
            _orderItemApp = orderItemApp;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
        {
            var Comments = await _commentApp.GetAllCustomer(CurrentCustomerId, cancellationToken);
            List<CommentViewModel> commentViewModel = null;
            if (Comments != null)
            {
                 commentViewModel = Comments.Select<CommentOutputDto, CommentViewModel>(c => new CommentViewModel
                 {
                     Id = c.Id,
                    IsConfirmed = c.IsConfirmed,
                    Text = c.Text,
                    Product = c.Product
                 }).ToList();

            }
            return View(commentViewModel);
        }


        [HttpGet]
        public async Task<ActionResult> CreateComment(int orderItemId, CancellationToken cancellationToken)
        {
            var orderItem = await _orderItemApp.GetDetail(orderItemId,cancellationToken);
            CommentViewModel commentViewModel = null;
            if (orderItem != null)
            {
                commentViewModel = new CommentViewModel
                {

                    Text = "",
                    OrderItemId = orderItemId,
                    OrderId = orderItem.OrderId,
                    OrderItemPrice = orderItem.BoothProduct.Price,
                    CustomerId = CurrentCustomerId,
                    Product = new Domain.Core._Products.Dtos.ProductDtos.ProductOutputDto{
                    Id = orderItem.ProductId,
                    Name = orderItem.BoothProduct.Product.Name,
                    Brand = orderItem.BoothProduct.Product.Brand }
                };
            }
            return View(commentViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> CreateComment(CommentViewModel commentViewModel, CancellationToken cancellationToken)
        {

            CommentCreateDto commentCreate = new CommentCreateDto
            {
                Text = commentViewModel.Text,
                ProductId = commentViewModel.Product.Id,
                OrderItemId = commentViewModel.OrderItemId,
                CustomerId = CurrentCustomerId,
            };
                await _commentApp.Create( commentCreate, cancellationToken );

            return RedirectToAction("OrderDetails", "Customer", new { OrderId = commentViewModel.OrderId });
        }

        [HttpGet]
        public async Task<ActionResult> EditComment(int commentId, CancellationToken cancellationToken)
        {
            var comment = await _commentApp.GetDetail(commentId, cancellationToken);
            UpdateCommentViewModel commentViewModel = new UpdateCommentViewModel
            {
                Id = comment.Id,
                Text = comment.Text,
            };
            return View(commentViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> EditComment(UpdateCommentViewModel commentViewModel, CancellationToken cancellationToken)
        {
            CommentUpdateDto updateDto = new CommentUpdateDto
            {
                 Id = commentViewModel.Id,
                 Text = commentViewModel.Text,
            };

            await _commentApp.Update(updateDto, cancellationToken);

            return RedirectToAction("GetAll");
        }


        [HttpGet]
        public async Task<ActionResult> DeleteComment(int commentId,CancellationToken cancellationToken)
        {
            
            await _commentApp.SoftDelete(commentId, cancellationToken);

            return RedirectToAction("GetAll");
        }
    }
}
