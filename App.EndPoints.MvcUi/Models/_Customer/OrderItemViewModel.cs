namespace App.EndPoints.MvcUi.Models._Customer
{
    public class OrderItemViewModel
    {
        public int OrderItemId { get; set; }

        public int price { get; set; }

        public int count { get; set; }

        public string ProductName { get; set; }

        public string Productbrand { get; set; }

        public string ProductPictureUrl { get; set; }
    }
}
