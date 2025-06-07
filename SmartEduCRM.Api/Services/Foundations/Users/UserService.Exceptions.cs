﻿using SmartEduCRM.Api.Models.Foundations.Users;
using SmartEduCRM.Api.Models.Foundations.Users.Exceptions;
using Xeptions;

namespace SmartEduCRM.Api.Services.Foundations.Users
{
    public partial class UserService
    {
        private delegate ValueTask<User> ReturningUserFunction();

        private async ValueTask<User> TryCatch(ReturningUserFunction returningUserFunction)
        {
            try
            {
                return await returningUserFunction();
            }
            catch (NullUserException nullUserException)
            {
                throw CreateAndLogValidationException(nullUserException);
            }
            catch (InvalidUserException invalidUserException)
            {
                throw CreateAndLogValidationException(invalidUserException);
            }
        }

        private UserValidationException CreateAndLogValidationException(Xeption exception)
        {
            var userValidationException = 
                new UserValidationException(exception);
            
            this.loggingBroker.LogError(userValidationException);
            
            return userValidationException;
        }
    }
}
