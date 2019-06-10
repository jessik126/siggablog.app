using SiggaBlog.Domain.Entity;
using SiggaBlog.Domain.Interface.Repository;

namespace SiggaBlog.Mediator.DataBase
{
    public class AlbumDatabase : BaseDatabase<AlbumEntity>
    {
        public AlbumDatabase(IAlbumRepository repository) : base(repository)
        {
        }
    }
}
