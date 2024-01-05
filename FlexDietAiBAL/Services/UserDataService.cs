using FlexDietAiDAL.Interfaces;
using FlexDietAiDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexDietAiBAL.Services
{
    public class UserDataService
    {
        public readonly IUserData _repository;

        public UserDataService(IUserData repository)
        {
            _repository = repository;
        }

        public async Task<UserData> AddUserDataAsync(UserData userData)
        {
            try
            {
                if (userData is null)
                    throw new ArgumentNullException();
                else
                    return await _repository.CreateAsync(userData);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<UserData> DeleteUserDataAsync(int Id)
        {
            try
            {
                var userData = await _repository.GetByIdAsync(Id);

                if(userData is null)
                    throw new ArgumentNullException();

                return await _repository.DeleteAsync(userData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<UserData?> UpdateUserDataAsync(int Id, UserData newUserData)
        {
            try
            {
                var userData = await _repository.GetByIdAsync(Id);

                if(userData is null)
                    throw new ArgumentNullException();

                return await _repository.UpdateAsync(Id, newUserData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<UserData?> GetUserDataByIdAsync(int Id)
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
