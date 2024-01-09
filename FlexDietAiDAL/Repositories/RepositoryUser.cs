using FlexDietAiDAL.Data;
using FlexDietAiDAL.Interfaces;
using FlexDietAiDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexDietAiDAL.Repositories
{    
    /// <summary>
    /// User repository to access database.
    /// </summary>
    public class RepositoryUser : IUser
    {
        FlexDietAiDbContext _dbContext;

        public RepositoryUser(FlexDietAiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> CreateAsync(User _object)
        {
            var obj = await _dbContext.Users.AddAsync(_object);
            await _dbContext.SaveChangesAsync();
            return obj.Entity;
        }

        public async Task<User> DeleteAsync(User user)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateAsync(Guid Id, User _object)
        {
            var user = await _dbContext.Users.FindAsync(Id);

            user.Email = _object.Email;
            user.BashPassword = _object.BashPassword;

            await _dbContext.SaveChangesAsync();
            return user;
            
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(Guid Id)
        {
            //var user = await _dbContext.Users.FindAsync(Id);
            var user = await _dbContext.Users
                                .Include(u => u.UserData)
                                .FirstOrDefaultAsync(u => u.UserId == Id);
            return user;
        }

        public async Task<User?> GetByLoginAsync(string email, string password)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.BashPassword == password);
            return user;
        }
    }
}
