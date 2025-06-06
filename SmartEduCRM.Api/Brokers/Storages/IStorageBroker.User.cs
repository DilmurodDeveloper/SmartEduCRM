using SmartEduCRM.Api.Models.Foundations;

namespace SmartEduCRM.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<User> InsertUserAsync(User user);

    }
}
