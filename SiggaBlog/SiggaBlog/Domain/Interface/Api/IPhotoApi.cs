using Refit;
using SiggaBlog.Domain.ServiceModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiggaBlog.Domain.Interface.Api
{
    public interface IPhotoApi
    {
        [Get("/photos?{key}={value}")]
        Task<IList<PhotoServiceModel>> Get(string key, string value);
    }
}
