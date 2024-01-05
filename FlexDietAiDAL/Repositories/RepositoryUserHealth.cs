using FlexDietAiDAL.Data;
using FlexDietAiDAL.Interfaces;
using FlexDietAiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexDietAiDAL.Repositories
{
    public class RepositoryUserHealth : IUserHealth
    {
        FlexDietAiDbContext _dbContext;

        public RepositoryUserHealth(FlexDietAiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserHealth> CreateAsync(UserHealth _object)
        {
            var obj = await _dbContext.UsersHealth.AddAsync(_object);
            await _dbContext.SaveChangesAsync();
            return obj.Entity;
        }

        public async Task<UserHealth> DeleteAsync(UserHealth _object)
        {
            _dbContext.UsersHealth.Remove(_object);
            await _dbContext.SaveChangesAsync();
            return _object;
        }

        public async Task<UserHealth> UpdateAsync(int Id, UserHealth _object)
        {
            var userHealth = await _dbContext.UsersHealth.FindAsync(Id);

            userHealth.Height = _object.Height;
            userHealth.Weight = _object.Weight;
            userHealth.Age = _object.Age;
            userHealth.Date = _object.Date;

            await _dbContext.SaveChangesAsync();
            return userHealth;
        }
        
        public async Task<UserHealth?> GetByIdAsync(int Id)
        {
            return await _dbContext.UsersHealth.FindAsync(Id);
        }
    }
}
