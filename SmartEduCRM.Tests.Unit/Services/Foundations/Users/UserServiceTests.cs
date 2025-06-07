using Moq;
using SmartEduCRM.Api.Brokers.Storages;
using SmartEduCRM.Api.Models.Foundations.Users;
using SmartEduCRM.Api.Services.Foundations.Users;
using Tynamix.ObjectFiller;

namespace SmartEduCRM.Tests.Unit.Services.Foundations.Users
{
    public partial class UserServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly IUserService userService;

        public UserServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();

            this.userService =
                new UserService(this.storageBrokerMock.Object);
        }

        private static User CreateRandomUser() =>
            CreateUserFiller(date: GetRandomDateTimeOffset()).Create();

        private static DateTimeOffset GetRandomDateTimeOffset() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static Filler<User> CreateUserFiller(DateTimeOffset date)
        {
            var filler = new Filler<User>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(date);

            return filler;
        }
    }   
}
