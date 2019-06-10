namespace SiggaBlog.Domain.ServiceModel
{
    public class PhotoServiceModel : BaseServiceModel
    {
        public string Title { get; set; }

        public string Url { get; set; }

        public string ThumbnailUrl { get; set; }

        public int AlbumId { get; set; }
    }
}
