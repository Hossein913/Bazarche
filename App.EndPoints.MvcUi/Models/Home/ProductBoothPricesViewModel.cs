namespace App.EndPoints.MvcUi.Models.Home
{
    public class ProductBoothPricesViewModel
    {
        public int Id { get; set; }
        public int Price { get; set; }

        public BoothViewModel Booth { get; set; }


    }
}
