using System;
using Data_Access_Layer.Context;
using Data_Access_Layer.Data;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer
{
    public class UserDAL
    {
        private readonly MyDbContext _context;

        public UserDAL()
        {
            _context = new MyDbContext();
        }

        public async Task<UserEntityModel> AddUser(UserEntityModel user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<UserEntityModel> GetUserByEmail(string email)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.email == email);
        }

        public async Task<List<UserEntityModel>> GetUsers()
        {
            return await _context.User.ToListAsync();
        }


    }
}

