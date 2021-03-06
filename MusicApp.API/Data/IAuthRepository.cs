using System.Collections.Generic;
using System.Threading.Tasks;
using MusicApp.API.Models;

namespace MusicApp.API.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password);

         Task<User> Login(string username, string password);

         Task<bool> UserExists(string username);
    }
}