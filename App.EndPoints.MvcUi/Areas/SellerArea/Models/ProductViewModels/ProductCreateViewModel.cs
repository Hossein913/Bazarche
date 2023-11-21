using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.MvcUi.Areas.SellerArea.Models.ProductViewModels
{
    public class ProductCreateViewModel
    {

        [DisplayName("نام"), Required(ErrorMessage = "نام محصول نمی تواند خالی باشد.")]
        public string Name { get; set; }

        [DisplayName("برند"),]
        public string Brand { get; set; }

        [DisplayName("نوع ضمانت"), Required(ErrorMessage = "نوع ضمانت را تعیین کنید.")]
        public string Grantee { get; set; }

        [DisplayName("جزئیات")]
        public string InformationDetails { get; set; }

        [DisplayName("توضیحات"), Required(ErrorMessage = "یک توضیح حداقلی ار کالا ارائه دهید")]
        public string Description { get; set; }

        [DisplayName("اجزا همراه")]
        public string IncludedComponents { get; set; }

        [DisplayName("کف قیمتی (به تومان)"), Required(ErrorMessage = "کمینه قیمت کالا را مشخص کنید.")]
        public int BasePrice { get; set; }

        [DisplayName("تصاویر کالا")]
        [MaxLength(3, ErrorMessage = "بیش از 4 تصویر نمی توان انخاب کرد.")]
        //[Required(ErrorMessage = "کالا باید حداقل یک تصویر داشته باشد.")]
        public List<IFormFile>? Pictures { get; set; }

        [DisplayName("دسته بندی ها را انتخداب کنید")]
        public int CategoryId { get; set; }

    }
}
