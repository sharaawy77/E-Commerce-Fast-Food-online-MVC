using System.Collections.Generic;

namespace Fast_Food_online.Services
{
    public interface IProductService<T>
    {
        public Task<List<T>> GetValuesAsync();
        public Task<T> GetValueAsync(int id);
        public Task UpdateAsync(T model);
        public Task DeleteAsync(int id);
        public Task AddAsync(T model);
    }
}
