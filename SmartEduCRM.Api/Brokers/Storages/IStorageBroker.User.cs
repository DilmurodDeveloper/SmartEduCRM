using SmartEduCRM.Api.Models.Foundations.Users;

namespace SmartEduCRM.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<User> InsertUserAsync(User user);

    }
}
