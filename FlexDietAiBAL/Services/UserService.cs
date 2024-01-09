using FlexDietAiDAL.Interfaces;
using FlexDietAiDAL.Models;
using FlexDietAiDAL.Repositories;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexDietAiBAL.Services
{
    public class UserService
    {
        public readonly IUser _repository;

        public UserService(IUser repository)
        {
            _repository = repository;
        }

        public async Task<User> AddUserAsync(User user)
        {
            try
            {
                if (user is null)
                    throw new ArgumentNullException();
                else
                    return await _repository.CreateAsync(user);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<User?> DeleteUserAsync(Guid Id)
        {
            try
            {
                var user = await _repository.GetByIdAsync(Id);
                    
                if(user is null)
                    throw new ArgumentNullException();

                return await _repository.DeleteAsync(user);
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User?> UpdateUserAsync(Guid Id, User newUser)
        {
            try
            {
                var user = await _repository.GetByIdAsync(Id);

                if (user is null)
                    throw new ArgumentNullException();

                return await _repository.UpdateAsync(Id, newUser);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<User?> GetUserByIdAsync(Guid Id)
        {
            try
            {
                return await _repository.GetByIdAsync(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User?> GetUserByLoginAsync(string email, string password)
        {
            try
            {
                return await _repository.GetByLoginAsync(email, password);
            }catch (Exception)
            {
                throw;
            }
        }
    }
}
