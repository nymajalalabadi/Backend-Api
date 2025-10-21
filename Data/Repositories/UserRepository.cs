using Data.Context;
using Domian.Entities.User;
using Domian.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Constructor

        private readonly ReactivitiesContext _context;

        public UserRepository(ReactivitiesContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<User> GetUserById(int Id)
        {
            return await _context.Users.FindAsync(Id);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetUserByUserName(string userName)
        {         
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == userName);
        }

        public async Task AddUser(User user)
        {
           await _context.Users.AddAsync(user);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
