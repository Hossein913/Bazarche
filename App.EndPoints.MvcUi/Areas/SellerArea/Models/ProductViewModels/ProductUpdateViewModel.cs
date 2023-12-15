using App.Domain.Core._Common.Entities;
using App.Domain.Core._Products.Dtos.CategorieDtos;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.MvcUi.Areas.SellerArea.Models.ProductViewModels
{
    public class ProductUpdateViewModel
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

        [DisplayName("تصاویر کالا")]
        public List<IFormFile>? UploadPictures { get; set; }

        public List<Picture>? PicturesFile { get; set; }

        [DisplayName("دسته بندی ها را انتخاب کنید")]
        public int CategoryId { get; set; }

        public List<CategoryOutputDto>? Categories { get; set; }

    }
}
