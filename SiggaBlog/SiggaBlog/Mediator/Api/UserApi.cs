using SiggaBlog.Domain.Interface.Api;
using SiggaBlog.Domain.ServiceModel;
using System.Threading.Tasks;

namespace SiggaBlog.Mediator.Api
{
    class UserApi : IUserApi
    {
        private readonly IUserApi _api;

        public UserApi(IUserApi api)
        {
            _api = api;
        }

        public async Task<UserServiceModel> Get(int id)
        {
            return await _api.Get(id);
        }
    }
}
