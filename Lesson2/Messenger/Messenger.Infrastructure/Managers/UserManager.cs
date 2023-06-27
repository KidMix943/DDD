using Messenger.Domain;
using Messenger.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Infrastructure.Managers
{
        public class UserManager : IUserManager
        {
            private readonly UserContext _context;
            public UserManager(UserContext context)
            {
                _context = context;
            }

            public async Task<List<User>> GetAll()
            {
                return await _context.Users.ToListAsync();
            }

            public async Task<User?> GetById(long id)
            {
                return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            }
            public async Task<User?> Info(long? id)
            {
            if (id is null || _context.Users is null)
            {
                return null;
            }
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user is null)
            {
                return null;
            }

            return user;
        }

            public async Task<User> Create(User user)
            {
                var entry = await _context.AddAsync(user);
                await _context.SaveChangesAsync();
                return entry.Entity;
            }
            public async Task<User?> Update(User user)
            {
                var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
                if (existingUser is null)
                {
                    return null;
                }

                existingUser.Login = user.Login;
                existingUser.Password = user.Password;
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.City = user.City;
                existingUser.Date = user.Date;

                var entry = _context.Update(existingUser);
                await _context.SaveChangesAsync();
                return entry.Entity;
            }
            public async Task<User?> Delete(long id)
            {
                var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
                if (existingUser is null)
                {
                    return null;
                }

                var entry = _context.Remove(existingUser);
                await _context.SaveChangesAsync();
                return entry.Entity;
            }

        }
    }
