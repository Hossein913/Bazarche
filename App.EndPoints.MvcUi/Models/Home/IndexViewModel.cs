using App.Domain.Core._Booth.Dtos.BoothDtos;
using App.Domain.Core._Products.Dtos.AuctionDtos;
using App.Domain.Core._Products.Dtos.CategorieDtos;

namespace App.EndPoints.MvcUi.Models.Home
{
    public class IndexViewModel
    {
        public List<AuctionViewModel> auctionViewModels { get; set; }
        public List<ProductViewModel> productsViewModels   { get; set; }
    }
}
