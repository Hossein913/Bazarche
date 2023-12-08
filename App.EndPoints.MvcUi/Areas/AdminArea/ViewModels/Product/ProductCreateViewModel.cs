using App.Domain.Core._Common.Entities;
using App.Domain.Core._Products.Dtos.CategorieDtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace App.EndPoints.MvcUi.Areas.AdminArea.ViewModels.Product
{
    public class ProductCreateViewModel
    {
        public int Id { get; set; }

        [DisplayName("نام"), Required(ErrorMessage = "نام محصول نمی تواند خالی باشد.")]
        public string Name { get; set; }

        [DisplayName("برند"),]
        public string Brand { get; set; }

        [DisplayName("نوع ضمانت"), Required(ErrorMessage = "نوع ضمانت را تعیین کنید.")]
        public string Grantee { get; set; }

        [DisplayName("جزئیات")]
        public string InformationDetails { get; set; }

        [DisplayName("توضیحات"), Required(ErrorMessage = "یک توضیح حداقلی از کالا ارائه دهید")]
        public string Description { get; set; }

        [DisplayName("اجزا همراه")]
        public string IncludedComponents { get; set; }

        [DisplayName("کف قیمتی (به تومان)"), Required(ErrorMessage = "کمینه قیمت کالا را مشخص کنید.")]
        public int BasePrice { get; set; }

        [DisplayName("تصاویر کالا"),MaxLength(4,ErrorMessage ="کالا نمی تواند بیش از 4 تصویر داشته باشد.")]
        [Required(ErrorMessage = "کالا باید حداقل یک تصویر داشته باشد.")]
        public List<IFormFile>? UploadPictures { get; set; }

        [DisplayName("دسته بندی ها را انتخاب کنید")]
        public int CategoryId { get; set; }

        public List<CategoryOutputDto>? Categories { get; set; }


    }
}
