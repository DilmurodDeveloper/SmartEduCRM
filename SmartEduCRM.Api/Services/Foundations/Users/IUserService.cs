using SmartEduCRM.Api.Models.Foundations.Users;

namespace SmartEduCRM.Api.Services.Foundations.Users
{
    public interface IUserService
    {
        ValueTask<User> AddUserAsync(User user);
    }
}
