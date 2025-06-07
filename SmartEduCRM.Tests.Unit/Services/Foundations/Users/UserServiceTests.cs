using System.Linq.Expressions;
using Moq;
using SmartEduCRM.Api.Brokers.Loggings;
using SmartEduCRM.Api.Brokers.Storages;
using SmartEduCRM.Api.Models.Foundations.Users;
using SmartEduCRM.Api.Services.Foundations.Users;
using Tynamix.ObjectFiller;
using Xeptions;

namespace SmartEduCRM.Tests.Unit.Services.Foundations.Users
{
    public partial class UserServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IUserService userService;

        public UserServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.userService = new UserService(
                this.storageBrokerMock.Object, 
                this.loggingBrokerMock.Object);
        }

        private static User CreateRandomUser() =>
            CreateUserFiller(date: GetRandomDateTimeOffset()).Create();

        private static DateTimeOffset GetRandomDateTimeOffset() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedException)
        {
            return actualException =>
                actualException.Message == expectedException.Message
                && actualException.InnerException.Message == expectedException.InnerException.Message
                && (actualException.InnerException as Xeption).DataEquals(expectedException.Data);
        }

        private static Filler<User> CreateUserFiller(DateTimeOffset date)
        {
            var filler = new Filler<User>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(date);

            return filler;
        }
    }   
}
