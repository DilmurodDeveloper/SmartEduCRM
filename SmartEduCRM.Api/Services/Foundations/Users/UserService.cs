using SmartEduCRM.Api.Brokers.Loggings;
using SmartEduCRM.Api.Brokers.Storages;
using SmartEduCRM.Api.Models.Foundations.Users;
using SmartEduCRM.Api.Models.Foundations.Users.Exceptions;

namespace SmartEduCRM.Api.Services.Foundations.Users
{
    public class UserService : IUserService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public UserService(
            IStorageBroker storageBroker, 
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public async ValueTask<User> AddUserAsync(User user)
        {
            try
            {
                if (user is null)
                {
                    throw new NullUserException();
                }

                return await this.storageBroker.InsertUserAsync(user);
            }
            catch (NullUserException nullUserException)
            {
                var userValidationException = 
                    new UserValidationException(nullUserException);

                this.loggingBroker.LogError(userValidationException);

                throw userValidationException; 
            }

        }
    }
}
