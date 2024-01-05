using FlexDietAiDAL.Interfaces;
using FlexDietAiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexDietAiBAL.Services
{
    public class UserHealthService
    {
        public readonly IUserHealth _repository;

        public UserHealthService(IUserHealth repository)
        {
            _repository = repository;
        }

        public async Task<UserHealth> AddUserHealthAsync(UserHealth userHealth)
        {
            try
            {
                if (userHealth is null)
                    throw new ArgumentNullException();
                else
                    return await _repository.CreateAsync(userHealth);
            }catch (Exception ex) { 
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<UserHealth> DeleteUserHealthAsync(int Id)
        {
            try
            {
                var userHealth = await _repository.GetByIdAsync(Id);

                if (userHealth is null)
                    throw new ArgumentNullException();

                return await _repository.DeleteAsync(userHealth);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<UserHealth> UpdateUserHealthAsync(int Id, UserHealth newUserHealth)
        {
            try
            {
                var userHealth = await _repository.GetByIdAsync(Id);

                if(userHealth is null)
                    throw new ArgumentNullException();

                return await _repository.UpdateAsync(Id, userHealth);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<UserHealth> GetUserHealthByIdAsync(int Id)
        {
            try
            {
                return await _repository.GetByIdAsync(Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
