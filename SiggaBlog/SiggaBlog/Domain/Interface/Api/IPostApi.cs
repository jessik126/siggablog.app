using Refit;
using SiggaBlog.Domain.ServiceModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiggaBlog.Domain.Interface.Api
{
    public interface IPostApi
    {
        [Get("/posts?{key}={value}")]
        Task<IList<PostServiceModel>> Get(string key, string value);
    }
}
