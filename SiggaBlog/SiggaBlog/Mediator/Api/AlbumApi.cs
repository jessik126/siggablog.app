using SiggaBlog.Domain.Interface.Api;
using SiggaBlog.Domain.ServiceModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiggaBlog.Mediator.Api
{
    public class AlbumApi : IAlbumApi
    {
        private readonly IAlbumApi _api;

        public AlbumApi(IAlbumApi api)
        {
            _api = api;
        }

        public async Task<IList<AlbumServiceModel>> Get()
        {
            return await _api.Get();
        }
    }
}
