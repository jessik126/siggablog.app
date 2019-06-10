namespace SiggaBlog.Domain.ServiceModel
{
    public class CommentServiceModel : BaseServiceModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Body { get; set; }

        public int PostId { get; set; }
    }
}
