using App.Domain.Core._Common.Entities;
using App.Domain.Core._Products.Entities;

namespace App.EndPoints.MvcUi.Models.Home
{
    public class CategoriesViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public int? ParentId { get; set; }

        public string PictureFileName { get; set; }

        public ICollection<Category> Subcategories { get; set; }

        public Picture? Picture { get; set; }

    }
}

//Id { get; set; }
//Title { get; set; } 
//ParentId { get; set; }
//PictureFileName { get; set; }
//Subcategories { get; set; }
//Picture { get; set; }