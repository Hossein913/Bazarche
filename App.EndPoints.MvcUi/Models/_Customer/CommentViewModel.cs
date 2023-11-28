namespace App.EndPoints.MvcUi.Models._Customer
{
    public class CommentViewModel
    {

        public string CustomerFullName { get; set; }

        public string Text { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

    }
}
