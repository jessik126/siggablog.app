using Refit;
using SiggaBlog.Domain.ServiceModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiggaBlog.Domain.Interface.Api
{
    public interface ICommentApi
    {
        [Get("/comments?{key}={value}")]
        Task<IList<CommentServiceModel>> Get(string key, string value);
    }
}
