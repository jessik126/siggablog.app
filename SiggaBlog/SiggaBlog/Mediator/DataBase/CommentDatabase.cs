using SiggaBlog.Domain.Entity;
using SiggaBlog.Domain.Interface.Repository;

namespace SiggaBlog.Mediator.DataBase
{
    public class CommentDatabase : BaseDatabase<CommentEntity>
    {
        public CommentDatabase(ICommentRepository repository) : base(repository)
        {
        }
    }
}
