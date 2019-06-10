namespace SiggaBlog.Domain.ServiceModel
{
    public class PostServiceModel : BaseServiceModel
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public int AlbumId { get; set; }
    }
}
