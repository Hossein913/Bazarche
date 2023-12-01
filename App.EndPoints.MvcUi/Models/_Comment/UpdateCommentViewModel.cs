using App.Domain.Core._Products.Dtos.ProductDtos;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.MvcUi.Models._Comment
{
    public class UpdateCommentViewModel
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        [Required(ErrorMessage = "متن نظر نمی تواند خالی باشد."), MaxLength(400, ErrorMessage = "متن پیام بسیار طولانی است."),]
        public string Text { get; set; } = null!;

    }
}
