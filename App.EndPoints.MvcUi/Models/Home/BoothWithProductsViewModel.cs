namespace App.EndPoints.MvcUi.Models.Home
{
    public class BoothWithProductsViewModel
    {
        public int id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string AvatarUrl { get; set; }

        public string MedalName { get; set; }



        public List<ProductViewModel> products { get; set; }
    }
}
