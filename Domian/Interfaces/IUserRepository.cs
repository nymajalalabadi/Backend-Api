using Domian.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int Id);

        Task<User> GetUserByEmail(string email);

        Task<User> GetUserByUserName(string userName);

        Task AddUser(User user);

        Task SaveChangesAsync();
    }
}
