using SiggaBlog.Domain.Interface.Api;
using SiggaBlog.Domain.ServiceModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiggaBlog.Mediator.Api
{
    public class PostApi : IPostApi
    {
        private readonly IPostApi _api;

        public PostApi(IPostApi api)
        {
            _api = api;
        }

        public async Task<IList<PostServiceModel>> Get(string key, string value)
        {
            return await _api.Get(key, value);
        }
    }
}
