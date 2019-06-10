using SiggaBlog.Domain.Entity;
using SiggaBlog.Domain.Interface.Repository;

namespace SiggaBlog.Mediator.DataBase
{
    public class PostDatabase : BaseDatabase<PostEntity>
    {
        public PostDatabase(IPostRepository repository) : base(repository)
        {
        }
    }
}
