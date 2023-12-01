using App.Domain.Core._Products.Dtos.ProductDtos;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.MvcUi.Models._Comment
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public ProductOutputDto Product { get; set; }

        public int CustomerId { get; set; }

        public int OrderItemId { get; set; }

        public int OrderItemPrice { get; set; }

        [Required(ErrorMessage = "متن نظر نمی تواند خالی باشد."), MaxLength(400, ErrorMessage = "متن پیام بسیار طولانی است."),]
        public string Text { get; set; } = null!;
        public bool? IsConfirmed { get; set; } = null!;

    }
}
