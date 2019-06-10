using SiggaBlog.Domain.Entity;
using SiggaBlog.Domain.Interface.Repository;

namespace SiggaBlog.Data.Repository
{
    public class AlbumRepository : BaseRepository<AlbumEntity>, IAlbumRepository
    {
    }
}
