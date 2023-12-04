namespace App.EndPoints.MvcUi.Areas.AdminArea.ViewModels.Comments
{
    public class AllCommentViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set;}
        public string CsutomerName { get; set;}
        public string CommentText { get; set;}
        public bool? IsConfirmed { get; set;}
        public string CreatedAt { get; set;}


    }
}
