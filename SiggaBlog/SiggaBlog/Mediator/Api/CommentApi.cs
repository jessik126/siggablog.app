using SiggaBlog.Domain.Interface.Api;
using SiggaBlog.Domain.ServiceModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiggaBlog.Mediator.Api
{
    public class CommentApi : ICommentApi
    {
        private readonly ICommentApi _api;

        public CommentApi(ICommentApi api)
        {
            _api = api;
        }

        public async Task<IList<CommentServiceModel>> Get(string key, string value)
        {
            return await _api.Get(key, value);
        }
    }
}
