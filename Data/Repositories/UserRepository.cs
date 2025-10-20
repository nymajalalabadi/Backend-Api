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

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

    }
}
