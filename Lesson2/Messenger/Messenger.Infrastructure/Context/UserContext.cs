using Microsoft.EntityFrameworkCore;
using Messenger.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
