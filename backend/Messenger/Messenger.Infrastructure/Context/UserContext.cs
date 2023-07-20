using Microsoft.EntityFrameworkCore;
using Messenger.Domain;

namespace Messenger.Infrastructure.Context
{
    public class UserContext:DbContext
    {
        public DbSet<User> Users => Set<User>();

        public UserContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }
    }
}
