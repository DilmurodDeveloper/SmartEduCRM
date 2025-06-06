using Microsoft.EntityFrameworkCore;
using SmartEduCRM.Api.Models.Foundations;

namespace SmartEduCRM.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<User> Users { get; set; }
    }
}
