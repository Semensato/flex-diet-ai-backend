using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexDietAiDAL.Interfaces
{
    /// <summary>
    /// Generical repository interface.
    /// </summary>
    public interface IRepository<T>
    {
        public Task<T> CreateAsync(T _object);
        public Task<T> DeleteAsync(T _object);
        public Task<T> UpdateAsync(int Id, T _object);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T?> GetByIdAsync(int Id);
    }
}
