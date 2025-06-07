using SmartEduCRM.Api.Models.Foundations.Users;
using SmartEduCRM.Api.Models.Foundations.Users.Exceptions;

namespace SmartEduCRM.Api.Services.Foundations.Users
{
    public partial class UserService
    {
        private void ValidateUserOnAdd(User user)
        {
            ValidateUserNotNull(user);
            
            Validate(
                (Rule: IsInvalid(user.Id), Parameter: nameof(User.Id)),
                (Rule: IsInvalid(user.FirstName), Parameter: nameof(User.FirstName)),
                (Rule: IsInvalid(user.LastName), Parameter: nameof(User.LastName)),
                (Rule: IsInvalid(user.Email), Parameter: nameof(User.Email)),
                (Rule: IsInvalid(user.PasswordHash), Parameter: nameof(User.PasswordHash)),
                (Rule: IsInvalid(user.Role), Parameter: nameof(User.Role))
            );
        }

        private void ValidateUserNotNull(User user)
        {
            if (user is null)
            {
                throw new NullUserException();
            }
        }

        private static dynamic IsInvalid(Guid id) => new
        {
            Condition = id == Guid.Empty,
            Message = "Id is required"
        };

        private static dynamic IsInvalid(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static dynamic IsInvalid(UserRole role) => new
        {
            Condition = Enum.IsDefined(role) is false,
            Message = "Role is invalid"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidUserException = new InvalidUserException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidUserException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidUserException.ThrowIfContainsErrors();
        }
    }
}
