namespace SiggaBlog.UI.Model
{
    public class CommentModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Comment { get; set; }

        public int PostId { get; set; }
    }
}
