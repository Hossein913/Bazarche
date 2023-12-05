using App.Domain.Core._Common.Entities;
using App.Domain.Core._Products.Dtos.CommentDtos;
using App.Domain.Core._Products.Entities;

namespace App.EndPoints.MvcUi.Areas.AdminArea.ViewModels.Product
{
    public class GetAllProductViewModel
    {

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Avatar { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool? IsConfirmed { get; set; }

        public int BasePrice { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CreatedBy { get; set; }



    }
}
