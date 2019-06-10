using Refit;
using SiggaBlog.Domain.ServiceModel;
using System.Threading.Tasks;

namespace SiggaBlog.Domain.Interface.Api
{
    public interface IUserApi
    {
        [Get("/users/{id}")]
        Task<UserServiceModel> Get(int id);
    }
}
