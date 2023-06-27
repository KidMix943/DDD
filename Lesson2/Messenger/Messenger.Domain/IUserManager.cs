using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Domain
{
    public interface IUserManager
    {
        Task<List<User>> GetAll();
        Task<User?> Info(long? id);
        Task<User?> GetById(long id);
        Task<User> Create(User user);
        Task<User?> Update(User user);
        Task<User?> Delete(long id);

    }
}
