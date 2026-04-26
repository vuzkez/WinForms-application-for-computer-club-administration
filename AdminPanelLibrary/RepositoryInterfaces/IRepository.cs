using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanelLibrary.RepositoryInterfaces
{
    public interface IRepository<T> where T : class
    {
        Task UpdateAsync(T entity);
        Task AddAsync(T entity);
        Task DeleteAsync(int id);
        Task<List<T>> GetAllAsync();
    }
}
