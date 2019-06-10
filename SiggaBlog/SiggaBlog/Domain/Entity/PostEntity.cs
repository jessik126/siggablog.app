namespace SiggaBlog.Domain.Entity
{
    public class PostEntity : BaseEntity
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public int AlbumId { get; set; }
    }
}
