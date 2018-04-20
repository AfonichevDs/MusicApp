using MusicApp.API.Data;
using MusicApp.API.Models;

namespace MusicApp.API.ApplicationLogic
{
    public class UsersRepository: Repository<User>, IUsersRepository
    {
        public UsersRepository(DataContext db) :base(db){}
    }
}