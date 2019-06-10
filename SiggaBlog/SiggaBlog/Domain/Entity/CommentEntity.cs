namespace SiggaBlog.Domain.Entity
{
    public class CommentEntity : BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Comment { get; set; }

        public int PostId { get; set; }
    }
}
