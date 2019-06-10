using SiggaBlog.Domain.Interface.Api;
using SiggaBlog.Domain.ServiceModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiggaBlog.Mediator.Api
{
    public class PhotoApi : IPhotoApi
    {
        private readonly IPhotoApi _api;

        public PhotoApi(IPhotoApi api)
        {
            _api = api;
        }

        public async Task<IList<PhotoServiceModel>> Get(string key, string value)
        {
            return await _api.Get(key, value);
        }
    }
}
