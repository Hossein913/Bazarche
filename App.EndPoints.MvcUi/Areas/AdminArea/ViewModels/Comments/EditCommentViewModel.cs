using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.MvcUi.Areas.AdminArea.ViewModels.Comments
{
    public class EditCommentViewModel
    {
        public int Id { get; set; }

        [Display(Name = "متن نظر")]
        [Required(ErrorMessage = "متن نظر نمی تواند خالی باشد."), MaxLength(400, ErrorMessage = "متن پیام بسیار طولانی است.")]
        public string Text { get; set; } = null!;

        public int? ProductId { get; set; }

        public string? ProductName { get; set; } = null!;

        public int? CustomerId { get; set; }

        public string? CustomerFullName { get; set; }


    }
}
