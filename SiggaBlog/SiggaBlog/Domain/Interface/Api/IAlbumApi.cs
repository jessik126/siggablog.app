using Refit;
using SiggaBlog.Domain.ServiceModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiggaBlog.Domain.Interface.Api
{
    public interface IAlbumApi
    {
        [Get("/albums")]
        Task<IList<AlbumServiceModel>> Get();
    }
}
