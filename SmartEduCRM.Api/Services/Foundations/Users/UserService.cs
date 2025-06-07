using SmartEduCRM.Api.Brokers.Storages;
using SmartEduCRM.Api.Models.Foundations.Users;

namespace SmartEduCRM.Api.Services.Foundations.Users
{
    public class UserService : IUserService
    {
        private readonly IStorageBroker storageBroker;

        public UserService(IStorageBroker storageBroker) =>
            this.storageBroker = storageBroker;

        public ValueTask<User> AddUserAsync(User user) =>
            throw new NotImplementedException();
    }
}
