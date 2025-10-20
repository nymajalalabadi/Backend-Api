using Domian.Entities.User;

namespace Backend_Api.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
