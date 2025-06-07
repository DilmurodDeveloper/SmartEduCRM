using SmartEduCRM.Api.Models.Foundations.Users;
using SmartEduCRM.Api.Models.Foundations.Users.Exceptions;

namespace SmartEduCRM.Api.Services.Foundations.Users
{
    public partial class UserService
    {
        private void ValidateUserNotNull(User user)
        {
            if (user is null)
            {
                throw new NullUserException();
            }
        }
    }
}
