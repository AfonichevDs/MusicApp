using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicApp.API.Data;
using MusicApp.API.Models;

namespace MusicApp.API.ApplicationLogic
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext dataContext;
        public AuthRepository(DataContext context)
        {
            dataContext = context;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await dataContext.Users.FirstOrDefaultAsync(u => u.UserName == username.ToLower());

            if(user == null || !VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
               return null;
               
            return user;   
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            
            await dataContext.AddAsync(user);
            await dataContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UserExists(string username) =>
            await dataContext.Users.AnyAsync(u => u.UserName == username);

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) 
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++) 
                {
                    if(passwordHash[i] != computedHash[i]) return false;
                }
                return true;
            }
        }
    }
}